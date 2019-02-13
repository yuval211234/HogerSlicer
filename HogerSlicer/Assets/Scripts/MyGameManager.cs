﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{

    private static MyGameManager GameManagerInstance { get; set; }

    [SerializeField]
    private static HogerSpawner ObjectSpawner;

    [SerializeField]
    public string CurrentMode;
    
    public static IGameModeBehavior CurrentGameMode { get; set; }

    private Dictionary<string, IGameModeBehavior> GameModeDictionary;

    private static MyGameManager gameManager;

    public static MyGameManager instance
    {
        get
        {
            if (!gameManager)
            {
                gameManager = FindObjectOfType(typeof(MyGameManager)) as MyGameManager;
                ObjectSpawner = FindObjectOfType(typeof(HogerSpawner)) as HogerSpawner;
                if (!gameManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    gameManager.Init();
                }
            }

            return gameManager;
        }
    }

    void Init()
    {
        EventManager.StartListening("CUT", Cut);
        EventManager.StartListening("MISS", Miss);

        if (GameModeDictionary == null)
        {
            GameModeDictionary = new Dictionary<string, IGameModeBehavior>();
            IGameModeBehavior untilWhenMode = new UntilWhenMode();
            GameModeDictionary.Add("UNTIL_WHEN", untilWhenMode);
        }

        CurrentGameMode = GameModeDictionary[CurrentMode];

        instance.InitGame();
        StartCoroutine("SpawnRoutine");
    }

    IEnumerator SpawnRoutine()
    {
        while (!CurrentGameMode.IsGameOver())
        {
            yield return new WaitForSeconds(CurrentGameMode.GetDelay());
            CurrentGameMode.Update();
        }


    }
    void Update()
    {
        if (CurrentGameMode != null)
        {
            if (CurrentGameMode.IsGameOver())
            {
                Time.timeScale = 0;
            }
        }
    }

    public int Score
    {
        get
        {
            return CurrentGameMode.GetScore();
        }
    }

    public int Lives
    {
        get
        {
            return CurrentGameMode.GetLives();
        }
    }

    internal void Restart()
    {
        InitGame();
    }

    private void InitGame()
    {
        CurrentGameMode.Init(ObjectSpawner);
    }

    public void Cut(string type)
    {
        CurrentGameMode.HandleCut(type);
    }

    public void Miss(string type)
    {
        CurrentGameMode.HandleMiss(type);
    }
}