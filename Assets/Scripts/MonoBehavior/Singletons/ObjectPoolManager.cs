using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingletonBase<ObjectPoolManager> 
{
    #region Field Declarations
    private List<ObjectPool> objectPools = new List<ObjectPool>();
    
    public List<ObjectPool> ObjectPools {get => objectPools; set => objectPools = value;}
    #endregion
    
    #region Unity Methods
    private void Start() 
    {
    	DontDestroyOnLoad(gameObject);
    }
    #endregion
    
    #region Custom Methods
    public void CreatePool(ObjectPool objectPool) 
    {
        objectPools.Add(objectPool);
    }
    
    public void RequestObjectFromPool() 
    {
    	// need help
    }
    #endregion
}
