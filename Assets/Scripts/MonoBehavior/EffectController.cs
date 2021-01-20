using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController
{
	#region Field Declarations
    private bool periodicActive;
    
    public IEnumerator PeriodicEffectRoutine {get => periodicEffectRoutine; set => periodicEffectRoutine = value;}
    public bool PeriodicActive {get => periodicActive; set => periodicActive = value;}
    #endregion
    
    #region Custom Methods
    public void ActivateEffect () 
    {
    	
    }
    #endregion

    #region Coroutines
    private IEnumerator periodicEffectRoutine ()
    {
		WaitForSeconds interval = new WaitForSeconds();
    }
    #endregion
}
