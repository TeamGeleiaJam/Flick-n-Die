using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable 
{
	#region Field Declarations
	public ObjectPool ObjectPool { get; set; }
	#endregion
	
    #region Custom Methods
    public void EnablePoolable();
    public void Pool();
    #endregion
}
