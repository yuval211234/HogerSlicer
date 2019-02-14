using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    public Texture2D[] texture = new Texture2D[3];
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = texture[Mathf.RoundToInt(Random.Range(0, texture.Length))];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
