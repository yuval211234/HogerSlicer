using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogerSpawner : MonoBehaviour {

	public GameObject hogerPrefab;
    public GameObject bombPrefab;
    public float bombSpawnProbability = 10;
    public float startForce = 15f;
    public Transform[] spawnPoints = new Transform[3];
    public Material[] hogerVariants = new Material[3];

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

            float currentSeed = Mathf.Round(Random.Range(1, bombSpawnProbability + 1));

            Debug.Log(currentSeed);

            if (currentSeed == bombSpawnProbability)
            {
                SpawnObjectAtRandomPoint(bombPrefab);
            }
            else
            {
                GameObject hogerObject = SpawnObjectAtRandomPoint(hogerPrefab);
                Material currentHogerMaterial = hogerVariants[Random.Range(0, hogerVariants.Length)];
                hogerObject.transform.GetChild(0).GetComponent<Renderer>().material = currentHogerMaterial;
            }
        }
	}

    private GameObject SpawnObjectAtRandomPoint(GameObject prefab)
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject spawnedObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        spawnedObject.GetComponent<Rigidbody2D>().AddForce(spawnedObject.transform.up * startForce, ForceMode2D.Impulse);
        Destroy(spawnedObject, 5f);

        return spawnedObject;
    }
	
}
