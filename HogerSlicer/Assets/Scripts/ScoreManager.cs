using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro ScoreText { get; set; }

    void Start()
    {
        ScoreText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        ScoreText.text = $"X {GameManager.GetInstace().GetScore()}";
    }
}
