using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoger : MonoBehaviour
{

    public GameObject fruitSlicedPrefab;
    public float startForce = 2f;
    private Camera mainCamera;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            CreateSlices(col);
            DestroyHoger();

            GameManager.GetInstace().HogerCut();
        }
    }

    private void DestroyHoger()
    {
        Destroy(gameObject);
    }

    private void CreateSlices(Collider2D col)
    {
        Vector3 direction = (col.transform.position - transform.position).normalized;
        GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, transform.rotation);
        Transform ChildGameObject1 = slicedFruit.transform.GetChild(0);
        Transform ChildGameObject2 = slicedFruit.transform.GetChild(1);
        ChildGameObject1.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity;
        ChildGameObject2.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity;
        ChildGameObject1.GetComponent<Renderer>().material = transform.GetChild(0).GetComponent<Renderer>().material;
        ChildGameObject2.GetComponent<Renderer>().material = transform.GetChild(0).GetComponent<Renderer>().material;
        Destroy(slicedFruit, 3f);
    }
}

}
