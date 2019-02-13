using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float initialRotation;

    void Start()
    {
        initialRotation = transform.rotation.z;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * initialRotation * 400);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            GameManager.GetInstace().Cut("MZ");
        }
    }
}
