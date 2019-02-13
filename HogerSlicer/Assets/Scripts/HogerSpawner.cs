using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogerSpawner : MonoBehaviour {

	public GameObject fruitPrefab;
	public Transform[] spawnPoints = new Transform[3];
    public Material[] hogerVariants = new Material[3];

	public float minDelay = .1f;
	public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits ()
	{
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            Material chosenMaterial = hogerVariants[Random.Range(0, hogerVariants.Length)];
            spawnedFruit.transform.GetChild(0).GetComponent<Renderer>().material = chosenMaterial;
            Destroy(spawnedFruit, 5f);
		}
	}
	
}
