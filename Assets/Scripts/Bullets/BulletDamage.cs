using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

	Bullet bullet;
	ParticleSystem ps;

	void Start () {
		bullet = GetComponent<Bullet> ();
		ps = GetComponentInChildren<ParticleSystem> ();
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth> ().TakeDamage (bullet.damage);
			StartCoroutine (ShowEffectsAndDie());
		}
	}

	IEnumerator ShowEffectsAndDie () {
		ps.Play ();
		yield return new WaitForSeconds (0.5f);
		ps.Stop ();
		gameObject.SetActive (false);
	}

}
