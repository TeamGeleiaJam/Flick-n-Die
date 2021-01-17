using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect Data", menuName = "Effects/Effect Data", order = 0)]
public class EffectData : ScriptableObject 
{
    #region Field Declarations
    [Header("Effect Paremeters")]
    [Tooltip("The damage applied by the effect.")]
    [SerializeField] private float damage = 0;
    [Tooltip("The range in units of the area of effect.")]
    [SerializeField] private float areaOfEffect = 0;
    [Tooltip("The delay before triggering the effect.")]
    [SerializeField] private float delay = 0;
    [Tooltip("The intensity multiplier of an effect.")]
    [SerializeField] [Range(0, 1)] private float intensity = 0;

    public float Damage { get => damage;}
    public float AreaOfEffect { get => areaOfEffect; }
    public float Delay { get => delay; }
    public float Intensity { get => intensity; }
    #endregion
}