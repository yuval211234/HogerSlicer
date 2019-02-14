using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowMuchMoreMode : IGameModeBehavior
{
    public float initialRotation;

    public HogerSpawner objectSpawner {get; private set;}
    public int Lives { get; private set; } = 3;
    public int Score { get; private set; } = 100;
    public int stage = 0;
    public float endMinDelay;
    public float endMaxDelay;
    public float startMinDelay = 1f;
    public float startMaxDelay = 2f;
    private bool isInFinalMode = false;
    public bool isPavelSpawned = false;
    private bool isEndGame = false;
    private float timeRemaining;

    public HowMuchMoreMode(int secondsToPlay)
    {
        isInFinalMode = false;
        isPavelSpawned = false;
        isEndGame = false;
        timeRemaining = secondsToPlay;
        endMinDelay = startMinDelay / 3;
        endMaxDelay = startMaxDelay / 3;
    }

    public void Update()
    {
        if (!isInFinalMode)
        {
            timeRemaining -= Time.deltaTime * 100;
            startMinDelay = Mathf.Lerp(startMinDelay, endMinDelay, Time.deltaTime * 2);
            startMaxDelay = Mathf.Lerp(startMaxDelay, endMaxDelay, Time.deltaTime * 2);
            if (timeRemaining <= 0)
            {
                isInFinalMode = true;
            }
            Spawn();
        } else
        {
            if (!isPavelSpawned)
            {
                isPavelSpawned = true;
                objectSpawner.SpawnPavel();
            }

        }

    }



    void Spawn()
    {
        int spawnCount = UnityEngine.Random.Range(1, 3);

        for (int i = 0; i < spawnCount; i++)
        {
            objectSpawner.SpawnHoger();
        }
    }

    public void HandleMiss(string type)
    {
        switch (type.ToUpper())
        {
            case "HOGER":
                MissedHogerCut();
                break;
            case "BOSSHOGER":
                isEndGame = true;
                break;
        }
    }

    public void HandleCut(string type)
    {
        switch (type.ToUpper())
        {
            case "HOGER":
                HogerCut();
                break;
        }
    }

    public void MissedHogerCut()
    {
        Lives--;
    }

    public void HogerCut()
    {
        Score += 1;
    }

    public bool IsGameOver()
    {
        return Lives <= 0 || isEndGame;
    }

    public int GetScore()
    {
        return Score;
    }

    public int GetLives()
    {
        return Lives;
    }

    public void Init(HogerSpawner ObjectSpawner)
    {
        Lives = 3;
        objectSpawner = ObjectSpawner;
    }

    public float GetDelay()
    {
        return UnityEngine.Random.Range(startMinDelay, startMaxDelay);
    }

    public string GetGameState()
    {
        TimeSpan time = TimeSpan.FromSeconds(Math.Round(timeRemaining));
        //here backslash is must to tell that colon is
        //not the part of format, it just a character that we want in output
        string str = time.ToString(@"mm\:ss");
        return str;
    }
}
