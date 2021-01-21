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

    private float lifeTimer;
    private ObjectPool objectPool;

    public EffectController EffectController {get => effectController;}
    public ItemData ItemData {get => itemData;}
    public ObjectPool ObjectPool { get => objectPool; set => objectPool = value; }
    public EItemType ItemType { get => itemType; set => itemType = value; }
    #endregion

    #region Interface Implementations
    public void EnablePoolable() 
    {

    }
    
    public void Pool()
    {
        // Notifies the object has despawned
        EventBroker.CallObjectDespawned();
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
        if (itemData.HitEffects.Count > 0) 
        {
            for (int i = 0; i < itemData.HitEffects.Count; i++) 
            {
                // do stuff with each effect data
            }
        }
    }
    
    #endregion
    
    #region Coroutines
    private IEnumerator LifetimeRoutine() 
    {
        yield return new WaitForSeconds(lifetime);

        Pool();
        
    	if (ObjectPoolManager.Instance.ObjectPools.ContainsKey(itemType)) 
    	{
            ObjectPool newItemPool = new ObjectPool();
            ObjectPoolManager.Instance.CreatePool(itemType, newItemPool);
    	}
    	else 
    	{
    		ObjectPoolManager.Instance.ObjectPools[itemType].ReturnObjectToPool(this.gameObject);
    	}
    }
    #endregion
}
