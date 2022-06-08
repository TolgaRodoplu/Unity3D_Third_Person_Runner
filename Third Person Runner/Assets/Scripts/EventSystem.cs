using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{

    public static EventSystem instance;
    public event Action gameStarted,  runningStarted, runningStopped, paintingStarted, paintingStopped, gameEnded;
    public event EventHandler<string> countdownUpdated;
    public event EventHandler<int> rankUpdated, percentUpdated;
    bool isStarted = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(!isStarted)
        {
            isStarted = true;
            StartGame();
        }
    }

    public void StartGame()
    {
        Debug.Log("GameStarted");
        gameStarted?.Invoke();
    }

    public void StartRunning()
    {
        Debug.Log("StartRunning");
        runningStarted?.Invoke();
    }

    public void StopRunning()
    {
        Debug.Log("StopRunning");
        runningStopped?.Invoke();
    }
    
    public void StartPainting()
    {
        Debug.Log("StartPainting");
        paintingStarted?.Invoke();
    }

    public void StopPainting()
    {
        Debug.Log("StopPainting");
        paintingStarted?.Invoke();
    }

    public void EndGame()
    {
        Debug.Log("EndGame");
        gameEnded?.Invoke();
    }

    public void UpdateRank(int newRank)
    {
        rankUpdated?.Invoke(this, newRank);
    }

    public void UpdatePercent(int newPercent)
    {
        percentUpdated?.Invoke(this, newPercent);
    }

    public void UpdateCountdown(string countdown)
    {
        countdownUpdated?.Invoke(this, countdown);
    }
}
