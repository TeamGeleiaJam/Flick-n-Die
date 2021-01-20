using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed Data", menuName = "Entity/Speed Data", order = 0)]
public class SpeedData : ScriptableObject 
{
    #region Field Declarations
    [Header("Speed Parameters")]
    [Tooltip("The speed property.")]
    [SerializeField] private float speed;
    
    public float Speed {get => speed;}
    #endregion
}
