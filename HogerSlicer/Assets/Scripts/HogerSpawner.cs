using System.Collections;
using UnityEngine;

public class HogerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints = new Transform[3];
    public Material[] hogerVariants = new Material[3];

	public GameObject hogerPrefab;
    public GameObject bombPrefab;
    public float bombSpawnProbability = 10;
    public float startForce = 15f;
	public int stage = 0;
    public float endMinDelay = .1f;
    public float maxDelay = 1f;
    public float startMinDelay = 1f;
    public float startMaxDelay = 2f;

    public GameManager GameManager { get; set; }

    float getMinDelay()
    {
        return startMinDelay;
    }

    float getMaxDelay()
    {
        return startMaxDelay;
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnFruits(GameManager.GetInstace()));
    }

    IEnumerator SpawnFruits(GameManager gameManager)
    {
        while (!GameManager.GetInstace().IsGameOver())
        {
            float delay = Random.Range(this.getMinDelay(), this.getMaxDelay());
            yield return new WaitForSeconds(delay);

            float currentSeed = Mathf.Round(Random.Range(1, bombSpawnProbability + 1));

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
        Rigidbody2D spawnedRigidBody2D = spawnedObject.GetComponent<Rigidbody2D>();
        spawnedRigidBody2D.AddForce(spawnedObject.transform.up * startForce, ForceMode2D.Impulse);
        //Destroy(spawedObject, 5f);

        return spawnedObject;
    }
}
