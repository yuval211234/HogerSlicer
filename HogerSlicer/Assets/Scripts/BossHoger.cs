using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHoger : MonoBehaviour
{

    public GameObject slicedObjectPrefab;
    public int ToSliceCount = 90;
    private int currCount = 0;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ToSliceCount <= 0)
        {
            EventManager.TriggerEvent("CUT", "BOSSHOGER");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade") { 

            ToSliceCount--;
            Debug.Log(ToSliceCount);
            if (ToSliceCount > 0)
            {
                Vector2 goTo = (rigidBody.position - col.gameObject.GetComponent<Rigidbody2D>().position).normalized * 6;
                goTo.y = 0;
                rigidBody.velocity = Vector2.up * 4 + goTo;
            } else
            {
                CreateSlices(col);
                DestroyHoger();
            }
            EventManager.TriggerEvent("CUT", "HOGER");
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
        InitSlicedHoger(ChildGameObject1, Vector2.left);
        InitSlicedHoger(ChildGameObject2, Vector2.right);
        ChildGameObject2.transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = transform.GetChild(1).GetComponent<Renderer>().material.mainTexture;
        Destroy(slicedFruit, 3f);
    }

    public void InitSlicedHoger(Transform hogerPart, Vector2 VectorToGive)
    {
        hogerPart.gameObject.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        hogerPart.GetComponent<Renderer>().material = transform.GetChild(0).GetComponent<Renderer>().material;
        hogerPart.gameObject.GetComponent<Rigidbody2D>().AddForce(VectorToGive * Random.Range(100, 200));
    }
}

