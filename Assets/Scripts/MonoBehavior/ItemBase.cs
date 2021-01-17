using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    private EffectController effectController { get; set; }
    private ItemData itemData { get; set; }
    private float lifetime;
    //TODO: Corroutine
    //TODO: Interface IPoolable
}
