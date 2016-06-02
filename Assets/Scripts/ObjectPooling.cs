using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour {

//	public static ObjectPooling current;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = true;
	List<GameObject> pooledObjects;



	// Use this for initialization
//	void Awake () {
//		current = this;
//	}
	
	// Update is called once per frame
	void Start () {
		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
			obj.transform.parent = transform;
		}
	}


	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++) 
		{
			if (!pooledObjects [i].activeInHierarchy) {
				return pooledObjects [i];
			}

		}

		if (willGrow) {
			GameObject obj = (GameObject)Instantiate (pooledObject);
			pooledObjects.Add (obj);
			obj.transform.parent = transform;
			return obj;
		}
		return null;


	}




}
	