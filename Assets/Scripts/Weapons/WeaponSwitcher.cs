using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WeaponSwitcher : MonoBehaviour {

	public List<Weapon> weapons = new List<Weapon> ();
	public List<Sprite> WeaponImages = new List<Sprite>();
	public Image weaponImage;
	public Weapon currentWeapon;

	int currentIndex = 0;

	void Start () {
		currentIndex = weapons.IndexOf (currentWeapon);
		SetCurrent ();
	}
	
	void Update () {
		if (Input.GetButtonDown("NextWeapon")) {
			if (currentIndex < weapons.Count-1) currentIndex++;
			SetCurrent ();
		}
		if (Input.GetButtonDown("PrevWeapon")) {
			if (currentIndex > 0) currentIndex--;
			SetCurrent ();
		}
	}

	void SetCurrent() {
		currentWeapon = weapons [currentIndex];
		weaponImage.sprite = WeaponImages[currentIndex];
	}

}
