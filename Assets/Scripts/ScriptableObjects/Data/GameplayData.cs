using UnityEngine;

[CreateAssetMenu(fileName = "Gameplay Data", menuName = "Other/Gameplay Data", order = 0)]
public class GameplayData : ScriptableObject
{
    #region Field Declarations
    [Header("Gameplay Parameters")]
    [Tooltip("The interval between spawning an item at the arena.")]
    [SerializeField] private float spawnInterval = 3f;
    [Tooltip("The maximum number of items that can be in an arena at any given time.")]
    [SerializeField] private int maxItemNumber = 15;
    [Tooltip("The spawnpool of items for the game.")]
    [SerializeField] private SpawnpoolData spawnpool;

    public SpawnpoolData Spawnpool { get => spawnpool; }
    public int MaxItemNumber { get => maxItemNumber; }
    public float SpawnInterval { get => spawnInterval; }
    #endregion
}