using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenPlane : MonoBehaviour
{
    MyGameManager gameManager;
    void Start()
    {
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Untagged")
        {
            Destroy(col.gameObject);
            EventManager.TriggerEvent("MISS", col.gameObject.tag);
        }

    }
}
