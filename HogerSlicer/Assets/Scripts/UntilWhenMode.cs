using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntilWhenMode : IGameModeBehavior
{
    public float initialRotation;

    public HogerSpawner objectSpawner {get; private set;}
    public int Lives { get; private set; } = 3;
    public int Score { get; private set; } = 0;
    public bool IsMzCollision { get; private set; } = false;
    public float bombSpawnProbability = 10;
    public int stage = 0;
    public float endMinDelay = .1f;
    public float maxDelay = 1f;
    public float startMinDelay = 1f;
    public float startMaxDelay = 2f;

    public void Update()
    {
        Spawn();
    }



    void Spawn()
    {
        float delay = Random.Range(startMinDelay, startMaxDelay);
        new WaitForSeconds(delay);

        float currentSeed = Mathf.Round(Random.Range(1, bombSpawnProbability + 1));

        if (currentSeed == bombSpawnProbability)
        {
            objectSpawner.SpawnBomb();
        }
        else
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
        }
    }

    public void HandleCut(string type)
    {
        switch (type.ToUpper())
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

    public void Init(HogerSpawner ObjectSpawner)
    {
        Lives = 3;
        Score = 0;
        IsMzCollision = false;
        objectSpawner = ObjectSpawner;
    }

    public float GetDelay()
    {
        return Random.Range(startMinDelay, startMaxDelay);
    }
}
