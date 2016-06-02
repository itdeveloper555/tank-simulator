using UnityEngine;
using System.Collections;


public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public float currentHealth;
	[Range(0, 1)] public float defense = 0.5f;


	Animator anim;
	AudioSource enemyAudio;
	bool isDead;
	bool isSinking;



	void Awake ()
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		currentHealth = startingHealth;
	}

	void OnEnable () {
		currentHealth = startingHealth;
		isDead = false;
	}

	public void TakeDamage (float amount)
	{
		if(isDead)
			return;

		if (!enemyAudio.isPlaying)
			enemyAudio.Play ();

		currentHealth -= amount * defense;


		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;
		anim.SetTrigger ("Dead");
		enemyAudio.Play ();
		GetComponent <NavMeshAgent> ().enabled = false;
		StartCoroutine (Deactivator());
	}

	IEnumerator Deactivator () {
		yield return new WaitForSeconds (2);
		gameObject.SetActive (false);

	}


}
