using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Status Effect", menuName = "Effects/Status Effect", order = 0)]
public class StatusEffectData : ScriptableObject 
{
    #region Field Declarations
    [Header("Status Effect Parameters")]
    [Tooltip("The effects triggered by the status effect paramater.")]
    [SerializeField] private List<EffectData> effects = new List<EffectData>();
    [Tooltip("How long the status effect endures.")]
    [SerializeField] private float duration = 5;
    [Tooltip("Over how many ticks damage is applied.")]
    [SerializeField] private int ticks = 0;

    // Public accessors for the status effect variables 
    public int Ticks { get => ticks; }
    public float Duration { get => duration; }
    public List<EffectData> Effects { get => effects; }
    #endregion
}
