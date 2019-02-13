using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoger : MonoBehaviour {

	public GameObject fruitSlicedPrefab;

	Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{
			Vector3 direction = (col.transform.position - transform.position).normalized;
            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, transform.rotation);
            InitSlicedHoger(slicedFruit.transform.GetChild(0));
            InitSlicedHoger(slicedFruit.transform.GetChild(1));
            
            Destroy(slicedFruit, 3f);
			Destroy(gameObject);
		}
	}

    public void InitSlicedHoger(Transform hogerPart)
    {
        hogerPart.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity;
        hogerPart.GetComponent<Renderer>().material = transform.GetChild(0).GetComponent<Renderer>().material;
    }

}
