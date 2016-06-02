using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	public float rotationSpeed = 36f;

    Animator anim;
	Rigidbody rb;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
		rb = GetComponent <Rigidbody> ();
    }

    void FixedUpdate ()
    {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
        Move (v);
        Turn (h);
        Animating (h, v);
    }

	void Move (float v)
	{
		Vector3 movement = transform.forward * v * speed * Time.deltaTime;
		rb.MovePosition (transform.position + movement);
//		rb.AddForce (this.transform.forward * v * speed, ForceMode.Force);
	}

	void Turn (float h)
    {			
		Vector3 rotation = Vector3.up * rotationSpeed * h;
		Quaternion deltaRotation = Quaternion.Euler(rotation * Time.deltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void Animating (float h, float v)
    {
        bool moving = h != 0f || v != 0f;
		anim.SetBool ("IsMoving", moving);
    }
}
