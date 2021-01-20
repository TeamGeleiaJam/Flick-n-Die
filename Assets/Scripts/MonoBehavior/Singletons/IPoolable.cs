using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable 
{
	#region Field Declarations
	private ObjectPool objectPool;
	
	public ObjectPool ObjectPool {get => objectPool; set => objectPool = value;}
	#endregion
	
    #region Custom Methods
    public void EnablePoolable();
    public void Pool();
    #endregion
}
