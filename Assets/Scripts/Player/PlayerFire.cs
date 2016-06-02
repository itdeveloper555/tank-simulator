using UnityEngine;
using System.Collections;

public class PlayerFire : MonoBehaviour {

	WeaponSwitcher weaponSwitcher;
	float timer, fireTime;  

	void Start () {
		weaponSwitcher = GetComponent<WeaponSwitcher> ();
		fireTime = weaponSwitcher.currentWeapon.fireTime;
		timer = fireTime;
	}
	
	void Update () {
		timer += Time.deltaTime;
		fireTime = weaponSwitcher.currentWeapon.fireTime;
		if (Input.GetButtonDown("Fire1") && timer >= fireTime) {
			InvokeRepeating ("Fire", 0, fireTime);
		}
		if (Input.GetButtonUp("Fire1")) CancelInvoke ();
	}

	void Fire () {
		timer = 0f;

		Weapon weapon = weaponSwitcher.currentWeapon;

		AudioSource gunAudio = weapon.GetComponent<AudioSource> ();

		gunAudio.Play ();

		GameObject bullet = weapon.currentBulletPooler.GetPooledObject ();

		if (bullet == null) return;

		bullet.transform.position = weapon.gunEnd.position;
		bullet.transform.rotation=  weapon.gunEnd.rotation;
		bullet.SetActive(true);
	}
}