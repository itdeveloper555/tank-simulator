using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;
	[Range(0, 1)] public float defense = 0;
	public float currentHealth;
	public Slider healthSlider;

	Animator anim;
	PlayerMovement playerMovement;
	PlayerFire playerFire;
	bool isDead;
	bool damaged;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerMovement = GetComponent <PlayerMovement> ();
		playerFire = GetComponent <PlayerFire> ();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
	}

	void Update () {

		//переворот
		Vector3 rot = transform.eulerAngles;
		if (rot.x > 90 && rot.x < 270 || rot.z > 90 && rot.z < 270) {
			currentHealth = 0;
			healthSlider.value = currentHealth;
			if (!isDead) Death ();
		}
	}

	public void TakeDamage (int amount)
	{
		currentHealth -= amount * defense;
		healthSlider.value = currentHealth;
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;

		//playerShooting.DisableEffects ();
		anim.SetTrigger ("Die");
		playerMovement.enabled = false;
		playerFire.enabled = false;
		//playerShooting.enabled = false;
		Invoke("RestartLevel", 4f);
	}

	public void RestartLevel ()
	{
		SceneManager.LoadScene (0);
	}
}
