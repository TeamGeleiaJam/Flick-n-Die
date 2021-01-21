using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hurt Data", menuName = "Entity/Hurt Data", order = 0)]
public class HurtData : ScriptableObject  
{
    #region Field Declarations
    [Header("Hurt Parameters")]
    [Tooltip("The minimum hurt value for any hand at any given point.")]
    [SerializeField] private float minHurt;
    [SerializeField] private float hurt;

    public float MinHurt {get => minHurt;}
    public float Hurt { get => hurt; set => hurt = value; }
    #endregion
}
