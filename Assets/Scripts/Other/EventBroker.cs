using System;
using UnityEngine;

public static class EventBroker
{
    public static event Action<string> GameOver;

    public static void CallGameOver()
    {
        GameOver?.Invoke("aleatório");
    }
}

// classe -> classe (Publisher-subscriber)
// classe -> EventBroker -> classe (Event Broker)
// classe -> EventArgs -> EventBroker -> EventArgs -> classe (Event Broker, Proper)
// classe -> UnityEvent -> Custom Listener -> Custom Handler -> classe (ScriptableObject Tyranny)
