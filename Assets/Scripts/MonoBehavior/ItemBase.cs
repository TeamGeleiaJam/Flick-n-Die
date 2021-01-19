using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour, IPoolable 
{
	#region Field Declarations
    [SerializeField] private EffectController effectController;
    [SerializeField] private ItemData itemData;
    [SerializeField] private float lifetime;
    
    public EffectController EffectController {get => effectController;}
    public ItemData ItemData {get => itemData;}
    #endregion
    
    #region Interface Implementations
    public void EnablePoolable() 
    {
    	// need help
    }
    public void Pool()
    {
    	// need help
    }
    #endregion
    
    #region Coroutines
    private IEnumerator LifetimeRoutine() 
    {
    	yield return new WaitForSeconds(lifetime);
    	this.Pool();
    }
    #endregion
}
