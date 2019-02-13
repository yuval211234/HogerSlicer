using UnityEngine;

public class SlicedHoger : MonoBehaviour
{
    Rigidbody2D rbRight;
    Rigidbody2D rbLeft;
    GameObject rightSlicedHoger;
    GameObject leftSlicedHoger;
    float LeftHogerRotation;
    float RightHogerRotation;
    // Start is called before the first frame update
    void Start()
    {
        rightSlicedHoger = transform.GetChild(0).gameObject;
        leftSlicedHoger = transform.GetChild(1).gameObject;
        rbRight = rightSlicedHoger.GetComponent<Rigidbody2D>();
        rbLeft = rightSlicedHoger.GetComponent<Rigidbody2D>();
        LeftHogerRotation = Random.Range(20, 300);
        RightHogerRotation = Random.Range(20, 300);
    }

    // Update is called once per frame
    void Update()
    {
        rightSlicedHoger.transform.Rotate(Vector3.back, Time.deltaTime * LeftHogerRotation);
        leftSlicedHoger.transform.Rotate(Vector3.forward, Time.deltaTime * RightHogerRotation);
    }
}
