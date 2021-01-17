using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(filename = "Flick Data", menuname = "Flick Data", order = 0)]
public class FlickData : ScriptableObject 
{
    #region Field Declarations
    [Header("Flick Parameters")]
    [Tooltip("The maximum possible force applied on a single flick.")]
    [SerializeField] private float maxFlickForce;
    [Tooltip("The speed in which a single flick's force increases.")]
    [SerializeField] private float forceIncreaseSpeed;
    
    public float MaxFlickForce {get => maxFlickForce;}
    public float ForceIncreaseSpeed {get => forceIncreaseSpeed;}
    #endregion
}
