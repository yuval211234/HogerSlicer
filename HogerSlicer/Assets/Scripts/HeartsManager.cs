using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsManager : MonoBehaviour
{
    public Image Lives { get; set; }

    void Start()
    {
        Lives = GetComponent<Image>();

        for (int index = 0; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        int livesLeft = MyGameManager.instance.Lives;
        int hearts = transform.childCount;

        if (livesLeft < hearts)
        {
            transform.GetChild(livesLeft).gameObject.SetActive(false);
        }        
    }
}