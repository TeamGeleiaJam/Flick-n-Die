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
    private Collider[] spawnAreas;

    // Public accessors for player hands
    public GameObject PlayerBot { get => playerBot; }
    public GameObject PlayerTop { get => playerTop; }

    // Coroutine for spawning the objects
    private Coroutine spawnObjectRoutine;

    // Counter of active items
    private int activeItems = 0;

    #endregion

    #region State Machine Methods

    // Runs when entering the state
    public override void EnterState(GameManager gameManager)
    {
        // Caches references to both players
        playerTop = GameObject.Find("PlayerTop");
        playerBot = GameObject.Find("PlayerBot");

        EventBroker.ObjectDespawned += DecreaseActiveItemCount;

        // Caches references to all spawn areas
        GameObject[] spawnAreaGameObjects = GameObject.FindGameObjectsWithTag("SpawnArea");
        for (int index = 0; index < spawnAreaGameObjects.Length - 1; index++)
        {
            // NOTE: god help us with this code quality
            spawnAreas[index] = spawnAreaGameObjects[index].GetComponent<Collider>();
        }
    }

    // Runs when leaving the state
    public override void LeaveState(GameManager gameManager)
    {
        // Clears caches
        playerTop = null;
        playerBot = null;
        spawnAreas = null;

        // Unsubscribes from event
        EventBroker.ObjectDespawned -= DecreaseActiveItemCount;
    }

    // Runs once per frame
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
        // Caches to ease memory use
        WaitForSeconds spawnInterval = new WaitForSeconds(GameManager.Instance.GameplayData.SpawnInterval);

        // Loops forever
        while (true)
        {
            if (activeItems < GameManager.Instance.GameplayData.MaxItemNumber)
            {
                // NOTE: This code is a fucking mess, holy shit
                // engage XGE
                EItemType randomItem = RandomlyChooseItem().GetComponent<ItemBase>().ItemType;
                Vector3 randomPosition = RandomlyChoosePosition();

                ObjectPoolManager.Instance.RequestObjectFromPool(randomItem, randomPosition, Quaternion.identity);
            }

            yield return spawnInterval;
        }
    }

    // Randomly picks out a position to spawn the item in
    private Vector3 RandomlyChoosePosition()
    {
        // Picks out an area out of the spawn areas
        Collider chosenArea = spawnAreas[Random.Range(0, spawnAreas.Length - 1)];

        // Picks out a random point within the area
        return new Vector3(
            Random.Range(chosenArea.bounds.min.x, chosenArea.bounds.max.x),
            Random.Range(chosenArea.bounds.min.y, chosenArea.bounds.max.y),
            Random.Range(chosenArea.bounds.min.z, chosenArea.bounds.max.z)
        );
    }

    // Decreases the active object count
    private void DecreaseActiveItemCount()
    {
        activeItems--;
    }

    // Randomly picks out items to spawn
    private GameObject RandomlyChooseItem()
    {
        // Defines the total weight of the pool
        int totalWeight = 0;

        // Calculates the total weight in the pool
        foreach ((GameObject item, int weight) spawnableItem in GameManager.Instance.GameplayData.Spawnpool.ObjectWeightTuples)
        {
            totalWeight = +spawnableItem.weight;
        }

        // Randomly generates number between 0 and the total weight
        int randomWeight = Random.Range(0, totalWeight);

        // Loops through the pool
        foreach ((GameObject item, int weight) spawnableItem in GameManager.Instance.GameplayData.Spawnpool.ObjectWeightTuples)
        {
            // If the randomly generated number is smaller than (within the chances) the weight of the item, choose it
            if (randomWeight < spawnableItem.weight)
            {
                return spawnableItem.item;
            }
            else
            {
                // Else, subtract the weight of the item
                randomWeight -= spawnableItem.weight;
            }
        }

        // The code should never reach this far
        return null;
    }

    #endregion
}
