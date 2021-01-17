using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items", order = 0)]
public class ItemData : ScriptableObject
{
    #region Field Declarations
    [Header("Item Parameters")]
    [Tooltip("The periodic effects released by the item.")]
    [SerializeField] private List<EffectData> periodicEffects = new List<EffectData>();
    [Tooltip("The effect released when the item is flicked.")]
    [SerializeField] private List<EffectData> flickEffects = new List<EffectData>();
    [Tooltip("The effect released when the item hits a hand.")]
    [SerializeField] private List<EffectData> hitEffects = new List<EffectData>();
    [Tooltip("The status effects applied to the hand that is hit.")]
    [SerializeField] private List<StatusEffectData> hitStatusEffects = new List<StatusEffectData>();
    [Tooltip("The status effects applied to the hand that flicked the item.")]
    [SerializeField] private List<StatusEffectData> selfStatusEffects = new List<StatusEffectData>();

    [Header("Item Fluff")]
    [Tooltip("The name of the item.")]
    [SerializeField] private string itemName;
    [Tooltip("The description of the item.")]
    [SerializeField] private string itemDescription;

    // Public accessors for the item data variables
    public List<EffectData> PeriodicEffects { get => periodicEffects; }
    public List<EffectData> FlickEffects { get => flickEffects; }
    public List<EffectData> HitEffects { get => hitEffects; }
    public string ItemName { get => itemName; }
    public string ItemDescription { get => itemDescription; }
    #endregion
}
