using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : SingletonBase<MenuManager>
{
    #region Field Declaration

    [Header("Menu Parameters")]
    [Tooltip("The windows contained in the menu.")]
    [SerializeField] private Dictionary<string, GameObject> windows;
    [Tooltip("The sound of button clicks for the menu.")]
    [SerializeField] private AudioClip clickSound;

    #endregion

    #region Custom Methods

    // Switches the current active window to the desired active window
    public void SwitchToWindow(string desiredWindow, bool mouseEnabled = true)
    {
        // Sets the given menu active
        windows[desiredWindow].SetActive(true);

        // For each menu in the windows dictionary
        foreach (GameObject menu in windows.Values)
        {
            // Check if the menu is equal to the given menu
            if (menu != windows[desiredWindow])
            {
                // If it isn't, disable it
                menu.SetActive(false);
            }
        }

        // Disables mouse if mouseEnabled is false
        if (mouseEnabled == false)
        {
            // Locks the cursor and makes it invisible;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            // Unlocks the cursor and makes it visible;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        PlayClickSound();
    }

    // Overlays a window on top of the currently active window
    public void OverlayWindow(string desiredWindow, bool mouseEnabled = true)
    {
        // Sets the given menu active
        windows[desiredWindow].SetActive(true);

        // Disables mouse if mouseEnabled is false
        if (mouseEnabled == false)
        {
            // Locks the cursor and makes it invisible;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            // Unlocks the cursor and makes it visible;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Disables a particular window
    private void DisableWindow(string desiredWindow, bool mouseEnabled = true)
    {
        // Sets the given menu active
        windows[desiredWindow].SetActive(false);

        // Disables mouse if mouseEnabled is false
        if (mouseEnabled == false)
        {
            // Locks the cursor and makes it invisible;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            // Unlocks the cursor and makes it visible;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Plays a button click sound
    public void PlayClickSound()
    {
        AudioSource.PlayClipAtPoint(clickSound, AudioManager.Instance.Listener.gameObject.transform.position);
    }

    #endregion
}