using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingletonBase<ObjectPoolManager> 
{
    #region Field Declarations
    private Dictionary<EItemType, ObjectPool> objectPools = new Dictionary<EItemType, ObjectPool>();
    
    public Dictionary<EItemType, ObjectPool> ObjectPools {get => objectPools; set => objectPools = value;}
    #endregion
    
    #region Unity Methods
    private void Start() 
    {
    	DontDestroyOnLoad(gameObject);
    }
    #endregion
    
    #region Custom Methods
    public void CreatePool(EItemType itemType, ObjectPool objectPool) 
    {
        objectPools.Add(itemType, objectPool);
    }
    
    public void RequestObjectFromPool(EItemType itemType, Vector3 position, Quaternion rotation) 
    {
    	objectPools[itemType].RequestObject(position, rotation);
    }
    #endregion
}
