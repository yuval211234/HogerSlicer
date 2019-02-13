using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoger : MonoBehaviour
{
    public GameObject fruitSlicedPrefab;
    public float startForce = 2f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(Vector3.zero);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, transform.rotation);
            GameObject ChildGameObject1 = slicedFruit.transform.GetChild(0).gameObject;
            GameObject ChildGameObject2 = slicedFruit.transform.GetChild(1).gameObject;
            ChildGameObject1.GetComponent<Rigidbody2D>().velocity = rb.velocity;
            ChildGameObject2.GetComponent<Rigidbody2D>().velocity = rb.velocity;
            Destroy(slicedFruit, 3f);
            Destroy(gameObject);
        }
    }
}
