using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

	public float lifeTime = 3f;

	// Use this for initialization
	void OnEnable () {
		Invoke ("Destroy", lifeTime);
	}
	
	// Update is called once per frame
	void Destroy () {
		gameObject.SetActive (false);
	}

	void OnDisable(){
		CancelInvoke ();
	}
}
