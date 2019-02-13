using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager
{
    private static GameManager GameManagerInstance { get; set; }

    private int Saves { get; set; }
    private int Score { get; set; }

    private bool IsMzCollision { get; set; }
    private GameManager()
    {
        InitGame();
    }

    //// Start is called before the first frame update
    //void Start()
    //{
    //    InitGame();
    //    Score = 0;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (IsGameOver())
    //    {
    //        //end game
    //    }
    //}

    public static GameManager GetInstace()
    {
        if (GameManagerInstance == null)
            GameManagerInstance = new GameManager();

        return GameManagerInstance;
    }

    private void InitGame()
    {
        Saves = 3;
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
        Saves--;
    }

    public void HogerCut()
    {
        Score += 1;
    }

    public bool IsGameOver()
    {
        return Saves == 0 || IsMzCollision;
    }

    public int GetScore()
    {
        return Score;
    }
}
