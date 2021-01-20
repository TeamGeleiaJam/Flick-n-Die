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
    private ObjectPool objectPool;
    
    public EffectController EffectController {get => effectController;}
    public ItemData ItemData {get => itemData;}
    #endregion
    
    #region Interface Implementations
    public ObjectPool ObjectPool {get => objectPool; set => objectPool = value;}
    public void EnablePoolable() 
    {
    	
    }
    public void Pool()
    {
    	
    }
    #endregion

    #region Custom Methods

    public void OnFlick() 
    {
        if (itemData.FlickEffects.Count > 0) 
        {
            for (int i = 0; i < itemData.FlickEffects.Count; i++) 
            {
                // do stuff with each effect data
            }
        }
        
        StartCoroutine(FlickedRoutine());
    }
    
    public void OnActivate() 
    {
        if (itemData.PeriodicEffects.Count > 0) 
        {
            for (int i = 0; i < itemData.PeriodicEffects.Count; i++) 
            {
                // do stuff with each effect data
            }
        }
    }
    
    public void OnHitTarget(HurtController hurtController, StatusEffectController statusEffectController) 
    {
        if (itemData.ImpactEffects.Count > 0) 
        {
            for (int i = 0; i < itemData.ImpactEffects.Count; i++) 
            {
                // do stuff with each effect data
            }
        }
    }
    
    #endregion
    
    #region Coroutines
    private IEnumerator FlickedRoutine()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        do
        {
            yield return new WaitForSeconds(0.3f);
        } while (rb.velocity.magnitude < 0.5f);
        Destroy(gameObject);
    }

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
