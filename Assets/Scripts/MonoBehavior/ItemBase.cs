using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour, IPoolable 
{
	#region Field Declarations
	[SerializeField] private EItemType itemType;
    [SerializeField] private EffectController effectController;
    [SerializeField] private ItemData itemData;
    [SerializeField] private float lifetime;
    
    public EffectController EffectController {get => effectController;}
    public ItemData ItemData {get => itemData;}
    #endregion
    
    #region Interface Implementations
    public void EnablePoolable() 
    {
    	
    }
    public void Pool()
    {
    	
    }
    #endregion
    
    #region Custom Methods
    public void OnHit() 
    {
    	
    }
    public void OnActivate() 
    {
    	
    }
    public void OnHitTarget(HurtController hurtController, StatusEffectController statusEffectController) 
    {
    	
    }
    #endregion
    
    #region Coroutines
    private IEnumerator LifetimeRoutine() 
    {
    	yield return new WaitForSeconds(lifetime);
    	Pool();
    	if (ObjectPoolManager.objectPools.ContainsKey(itemType)) 
    	{
            ObjectPool newItemPool = new ObjectPool();
            ObjectPoolManager.CreatePool(itemType, newItemPool);
    	}
    	else 
    	{
    		ObjectPoolManager.objectPools[itemType].ReturnObjectToPool(this.gameObject);
    	}
    }
    #endregion
}
