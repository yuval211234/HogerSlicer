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
    public float endMinDelay;
    public float endMaxDelay;
    public float maxDelay = 1f;
    public float startMinDelay = 1f;
    public float startMaxDelay = 2f;

    public UntilWhenMode()
    {
        endMinDelay = startMinDelay;
        endMaxDelay = startMaxDelay;
    }

    public void Update()
    {
        startMinDelay = Mathf.Lerp(startMinDelay, endMinDelay / 3, Time.deltaTime);
        startMaxDelay = Mathf.Lerp(startMaxDelay, endMaxDelay / 3, Time.deltaTime);

        int maxSpawnCount = 1;

        if (startMinDelay <= 2 * endMinDelay / 3) maxSpawnCount++;
        if (startMinDelay <= endMinDelay / 2) maxSpawnCount++;

        int spawnCount = Random.Range(1, maxSpawnCount + 1);
        for (int i = 0; i < spawnCount; i++)
        {
            Spawn();
        }

    }



    void Spawn()
    {
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

    public string GetGameState()
    {
        return $"X {Score}";
    }
}
