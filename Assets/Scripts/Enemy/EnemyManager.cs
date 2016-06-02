using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
	public ObjectPooling currentEnemyPooler;
	public float spawnTime = 3f;
	public int maxEnemyCount = 3;

    void Start ()
    {
			InvokeRepeating ("Spawn", 0, spawnTime);
    }


    void Spawn ()
    {
		int aliveEnemyCount = CountAliveObjects ();
		if (aliveEnemyCount < maxEnemyCount) {
			aliveEnemyCount++;
			GameObject obj = currentEnemyPooler.GetPooledObject ();
			PlaceAndActivate (obj);
		}
    }

	int CountAliveObjects () {
		int countActive = 0;
		foreach (EnemyHealth en in currentEnemyPooler.GetComponentsInChildren<EnemyHealth>())
			if (en.gameObject.activeInHierarchy)
				countActive++;
		return countActive;
	}

	void PlaceAndActivate(GameObject obj) {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		obj.transform.position = spawnPoints[spawnPointIndex].position;
		obj.transform.rotation=  spawnPoints[spawnPointIndex].rotation;
		obj.GetComponent<NavMeshAgent> ().enabled = true;
		obj.SetActive(true);
	}

}
