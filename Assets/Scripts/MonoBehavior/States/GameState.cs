using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseGameState
{
    #region Field Declarations

    // Cache of the bottom and top players
    private GameObject playerTop;
    private GameObject playerBot;

    // Spawn points and spawnable objects
    private GameObject[] spawnAreas;

    // Public accessors for player hands
    public GameObject PlayerBot { get => playerBot; }
    public GameObject PlayerTop { get => playerTop; }

    // Coroutine for spawning the objects
    private Coroutine spawnObjectRoutine;

    #endregion

    #region State Machine Methods

    public override void EnterState(GameManager gameManager)
    {
        // Caches references to both players
        playerTop = GameObject.Find("PlayerTop");
        playerBot = GameObject.Find("PlayerBot");

        // Caches references to all spawn areas
        spawnAreas = GameObject.FindGameObjectsWithTag("SpawnArea");
    }

    public override void LeaveState(GameManager gameManager)
    {
        // Clears caches
        playerTop = null;
        playerBot = null;
        spawnAreas = null;
    }

    public override void Update(GameManager gameManager)
    {

    }

    #endregion

    #region Custom Methods

    // Ends the game and shows post-match screen
    private void GameOver()
    {
        EventBroker.CallGameOver();
    }

    // Spawns items periodically
    private IEnumerator SpawnObjects()
    {
        yield return null;
    }
    
    #endregion
}
