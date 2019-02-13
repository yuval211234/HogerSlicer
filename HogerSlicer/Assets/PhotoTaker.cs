using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhotoTaker : MonoBehaviour
{
    public Texture2D tex;
    public WebCamPhotoCamera camera;
    Button button;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnClick() {
        
        Texture2D tex2d = (Texture2D)camera.GetComponent<RawImage>().texture;
        tex.SetPixels(tex2d.GetPixels());
        Debug.Log(3);
    }
}
