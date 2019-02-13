using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreenPlane : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.GetInstace();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {            
        Destroy(col.gameObject);
        if (col.gameObject.tag == "Hoger")
        {
            gameManager.MissedHogerCut();
            Debug.Log("Missed cut");
        }
    }
}
