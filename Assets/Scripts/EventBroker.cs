using System;
using UnityEngine;

public static class EventBroker 
{
    // Events
    // Runs on game over
    public static event Action GameOver;
    // Runs once an object is requested from the object pool
    public static event Action RequestedObjectFromPool;
    // Runs once an object despawns
    public static event Action ObjectDespawned;

    // Callers
    public static void CallGameOver()
    {
        GameOver?.Invoke();
    }

    public static void CallRequestedObjectFromPool()
    {
        RequestedObjectFromPool?.Invoke();
    }

    public static void CallObjectDespawned()
    {
        ObjectDespawned?.Invoke();
    }
}