using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable 
{
    #region Custom Methods
    public void EnablePoolable();
    public void Pool();
    #endregion
}
