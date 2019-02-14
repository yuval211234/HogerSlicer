using System.Collections;
using UnityEngine;

public class HogerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints = new Transform[3];
    public Material[] hogerVariants = new Material[3];
    public GameObject bossPrefab;

    public GameObject hogerPrefab;
    public GameObject bombPrefab;


    public Transform bossSpawnPoint;
    public float startForce = 15f;


    private MyGameManager gameManager { get; set; }

    public GameObject SpawnBomb()
    {
        return SpawnObjectAtRandomPoint(bombPrefab);
    }

    public GameObject SpawnHoger()
    {
        GameObject hogerObject = SpawnObjectAtRandomPoint(hogerPrefab);
        Material currentHogerMaterial = hogerVariants[Random.Range(0, hogerVariants.Length)];
        hogerObject.transform.GetChild(0).GetComponent<Renderer>().material = currentHogerMaterial;

        return hogerObject;
    }

    private GameObject SpawnObjectAtRandomPoint(GameObject prefab)
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject spawnedObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D spawnedRigidBody2D = spawnedObject.GetComponent<Rigidbody2D>();
        spawnedRigidBody2D.AddForce(spawnedObject.transform.up * startForce, ForceMode2D.Impulse);

        return spawnedObject;
    }

    public GameObject SpawnPavel()
    {
        GameObject spawnedObject = Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
        Rigidbody2D spawnedRigidBody2D = spawnedObject.GetComponent<Rigidbody2D>();
        spawnedRigidBody2D.AddForce(spawnedObject.transform.up * startForce, ForceMode2D.Impulse);

        return spawnedObject;
    }
}
