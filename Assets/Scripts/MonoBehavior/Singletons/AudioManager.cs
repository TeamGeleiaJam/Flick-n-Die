using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : SingletonBase<AudioManager>
{
    #region Field Declarations

    // Cache for the AudioListener
    private AudioListener listener;
    // Public accessor for other classes
    public AudioListener Listener { get => listener; set => listener = value; }

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    private void Start()
    {
        // Marks the gameobject for permanence throughout scenes
        DontDestroyOnLoad(gameObject);

        // Subscribes GetSceneListener to scene loads
        SceneManager.sceneLoaded += GetSceneListener;
    }

    // Runs right before the GameObject is destroyed
    protected override void OnDestroy()
    {
        // Unsubscribes from load scene event
        SceneManager.sceneLoaded -= GetSceneListener;

        // Calls the regular singleton OnDestroy
        base.OnDestroy();
    }

    #endregion

    #region Custom Methods

    // Gets the currently active listener on the scene
    private void GetSceneListener(Scene scene, LoadSceneMode mode)
    {
        // Caches the main camera listener
        listener = Camera.main.gameObject.GetComponent<AudioListener>();
    }

    #endregion
}
