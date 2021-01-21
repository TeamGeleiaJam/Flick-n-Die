using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

// A singleton class of a given type T, which inherits from singletonbase of that same type T
public class SingletonBase<T> : SerializedMonoBehaviour where T : SingletonBase<T>
{
    // The global instance reference of the singleton
    private static T instance;
    public static T Instance { get => instance; }
    // An accessor to check whether the singleton has been initialized
    public static bool IsInitialized { get => instance != null; }

    // Overrideable check if another instance exists on awake
    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("A second instance of singleton " + (T)this + " has been initialized!");
        }
        else
        {
            // Set the instance to this class (typecasted to the given type)
            instance = (T)this;
        }
    }

    // An overrideable clear instance action
    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}