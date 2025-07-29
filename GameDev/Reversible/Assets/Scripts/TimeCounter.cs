using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public int elapsedRunningTime;
    public static int RewindTimer = 0;
    public static int TimerReverse = 0;
    private int counterReverse;
    
    private float runningStartTime = 0f;
    private float pauseStartTime = 0f;
    private float elapsedPausedTime = 0f;
    private float totalElapsedPausedTime = 0f;
    private bool running = true;
    private bool paused = false;

    

    public void ReverseTime(int reverseCounter)
    {
        TimerReverse = RewindTimer;
        counterReverse = reverseCounter;
    }

    public float GetRewindTimer()
    {
        return RewindTimer;
    }

    void FixedUpdate()
    {
        if (running)
        {
            elapsedRunningTime++;
            RewindTimer += (int)(Math.Pow(-1,counterReverse));
        }
        else if (paused)
        {
            elapsedPausedTime = Time.time - pauseStartTime;
        }
    }
  
    public void Begin()
    {
        if (!running && !paused)
        {
            runningStartTime = Time.time;
            running = true;
        }
    }
  
    public void Pause()
    {
        if (running && !paused)
        {
            running = false;
            pauseStartTime = Time.time;
            paused = true;
        }
    }
  
    public void Unpause()
    {
        if (!running && paused)
        {
            totalElapsedPausedTime += elapsedPausedTime;
            running = true;
            paused = false;
        }
    }
  
    public void Reset()
    {
        RewindTimer = 0;
        elapsedRunningTime = 0;
        runningStartTime = 0f;
        pauseStartTime = 0f;
        elapsedPausedTime = 0f;
        totalElapsedPausedTime = 0f;
        running = false;
        paused = false;
    }
  
    public int GetMinutes()
    {
        return (int)(elapsedRunningTime / 60f);
    }
  
    public int GetSeconds()
    {
        return (int)(elapsedRunningTime);
    }
  
 
 
    public float GetRawElapsedTime()
    {
        return elapsedRunningTime;
    }
}

