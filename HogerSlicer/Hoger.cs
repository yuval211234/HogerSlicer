using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoger : MonoBehaviour
{

    public GameObject slicedObjectPrefab;
    public float startForce = 2f;
    public float initialRotation;
    public float flipRotation;

    void Start()
    {
        initialRotation = transform.rotation.z;
        float randomMultiplier = Random.Range(-2, 2);
        flipRotation = Random.Range(20, 120) * randomMultiplier;
    }

    void Update()
    {
        transform.Rotate(Vector3.right, Time.deltaTime * flipRotation);
        transform.Rotate(Vector3.forward, Time.deltaTime * initialRotation * 200);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            CreateSlices(col);
            DestroyHoger();

            GameManager.GetInstace().Cut("HOGER");
        }
    }

    private void DestroyHoger()
    {
        Destroy(gameObject);
    }

    private void CreateSlices(Collider2D col)
    {
        Vector3 direction = (col.transform.position - transform.position).normalized;
        GameObject slicedFruit = Instantiate(slicedObjectPrefab, transform.position, transform.rotation);
        Transform ChildGameObject1 = slicedFruit.transform.GetChild(0);
        Transform ChildGameObject2 = slicedFruit.transform.GetChild(1);
        InitSlicedHoger(ChildGameObject1);
        InitSlicedHoger(ChildGameObject2);
        ChildGameObject2.transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = transform.GetChild(1).GetComponent<Renderer>().material.mainTexture;
        Destroy(slicedFruit, 3f);
    }

    public void InitSlicedHoger(Transform hogerPart)
    {
        hogerPart.gameObject.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        hogerPart.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
        hogerPart.GetComponent<Renderer>().material = transform.GetChild(0).GetComponent<Renderer>().material;

    }

}
