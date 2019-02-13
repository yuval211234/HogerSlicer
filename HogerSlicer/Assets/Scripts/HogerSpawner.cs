using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogerSpawner : MonoBehaviour {

	public GameObject fruitPrefab;
	public Transform[] spawnPoints;

	public int stage = 0;

	public float endminDelay = .1f;
	public float maxDelay = 1f;

	public float startMinDelay = 1f;
	public float startMaxDelay = 2f;

	float getMinDelay() {
		return startMinDelay;
	}

	float getMaxDelay() {
		return startMaxDelay;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits ()
	{
		while (true)
		{
			float delay = Random.Range(this.getMinDelay(), this.getMaxDelay());
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnedFruit, 5f);
		}
	}
	
}
