using System.Collections;
using UnityEngine;

public class HogerSpawner : MonoBehaviour {

	public GameObject fruitPrefab;
	public Transform[] spawnPoints = new Transform[3];
  public Material[] hogerVariants = new Material[3];

	public int stage = 0;

    public float endMinDelay = .1f;
    public float maxDelay = 1f;

    public float startMinDelay = 1f;
    public float startMaxDelay = 2f;

    public GameManager GameManager { get; set; }

    float getMinDelay() {
		return startMinDelay;
	}

	float getMaxDelay() {
		return startMaxDelay;
	}

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnFruits(GameManager.GetInstace()));
	}

	IEnumerator SpawnFruits (GameManager gameManager)
	{
		while (!GameManager.GetInstace().IsGameOver())
		{
			float delay = Random.Range(this.getMinDelay(), this.getMaxDelay());
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
