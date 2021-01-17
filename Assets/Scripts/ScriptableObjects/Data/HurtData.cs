using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(filename = "Hurt Data", menuname = "Entity/Hurt Data", order = 0)]
public class HurtData : ScriptableObject  
{
    #region Field Declarations
    [Header("Hurt Parameters")]
    [Tooltip("The minimum hurt value for any hand at any given point.")]
    [SerializeField] private float minHurt;
    
    public float MinHurt {get => minHurt;}
    #endregion
}
