using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	public float speed = 5;
	public bool isKinematic = true;

	void OnEnable () {
		if (!isKinematic)
			GetComponent<Rigidbody> ().velocity = (transform.forward * speed);
	}

	void Update () {
		if (isKinematic)
			transform.Translate (0, 0, speed * Time.deltaTime);
	}
}