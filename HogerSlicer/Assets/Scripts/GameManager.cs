using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager
{
    private static GameManager GameManagerInstance { get; set; }

    private int Lives { get; set; }
    private int Score { get; set; }

    private bool IsMzCollision { get; set; }
    private GameManager()
    {
        InitGame();
        Time.timeScale = 1;
    }

    public static GameManager GetInstace()
    {
        if (GameManagerInstance == null)
            GameManagerInstance = new GameManager();

        return GameManagerInstance;
    }

    private void InitGame()
    {
        Lives = 3;
        IsMzCollision = false;
        Score = 0;
    }

    public void Cut(string type)
    {
        switch(type.ToUpper())
        {
            case "MZ":
                CollideMzReport();
                break;
            case "HOGER":
                HogerCut();
                break;
        }
    }

    public void CollideMzReport()
    {
        IsMzCollision = true;
    }

    public void MissedHogerCut()
    {
        Lives--;
        if (IsGameOver())
        {
            Time.timeScale = 0;
        }
    }

    public void HogerCut()
    {
        Score += 1;
    }

    public bool IsGameOver()
    {
        return Lives <= 0 || IsMzCollision;
    }

    public int GetScore()
    {
        return Score;
    }

    public int GetLives()
    {
        return Lives;
    }
}
