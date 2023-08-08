using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class EventBus 
{
    public static Action startGame;
    public static Action finishGame;
    public static Action catchPoint;

    public static void GetCatchPoint()
    {
        catchPoint?.Invoke();
    }

    public static void GetStarted()
    {
        startGame?.Invoke();
    }

    public static void GetFinished()
    {
        finishGame?.Invoke();
    }
}
