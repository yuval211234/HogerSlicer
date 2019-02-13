using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenPlane : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
            Debug.Log("Collision");
            Destroy(col.gameObject);
    }
}
