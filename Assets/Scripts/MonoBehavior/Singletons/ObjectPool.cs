using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool 
{
	#region Field Declarations
	[Header("Object Pool Parameters")]
    private List<GameObject> inactiveObjects = new List<GameObject>();
    private List<GameObject> activeObjects = new List<GameObject>();
    [Tooltip("The time in seconds between each pool cleanup.")]
    [SerializeField] private float cleanupTime;
    [Tooltip("The maximum amount of objects the pool will have after each cleanup.")]
    [SerializeField] private int maxObjectCount;
    
    public List<GameObject> InactiveObjects {get => inactiveObjects; set => inactiveObjects = value;}
    public float CleanupTime {get => cleanupTime;}
    public int MaxObjectCount {get => maxObjectCount;}
    #endregion
    
    #region Custom Methods
    public GameObject RequestObject(Vector3 position, Quaternion rotation) 
    {
    	int returnedObjectIndex = inactiveObjects.Count - 1;
    	GameObject returnedObject = inactiveObjects[returnedObjectIndex];
    	inactiveObjects.RemoveAt(returnedObjectIndex);
    	activeObjects.Add(returnedObject);
    	IPoolable returnedObjectInterface = returnedObject.GetComponent<IPoolable>();
    	
    	returnedObjectInterface.EnablePoolable();
    	returnedObject.SetActive(true);
    	returnedObject.position = position;
    	returnedObject.rotation = rotation;
    	
    	return returnedObject;
    }
    private void DeletePool() 
    {
    	if (inactiveObjects.Count > 0) 
    	{
    		inactiveObjects.RemoveRange(0, inactiveObjects.Count);
    	}
    	if (activeObjects.Count > 0) 
    	{
    		activeObjects.RemoveRange(0, activeObjects.Count);
    	}
    }
    public void AddObjectToPool() 
    {
    	GameObject instantiatedObject = Instantiate(inactiveObjects[0]);
    	IPoolable instantiatedObjectInterface = instantiatedObject.GetComponent<IPoolable>();
    	
    	instantiatedObjectInterface.ObjectPool = this;
    	instantiatedObject.SetActive(false);
    	inactiveObjects.Add(instantiatedObject);
    }
    public void ReturnObjectToPool(GameObject gameObject) 
    {
        gameObject.SetActive(false);
        activeObjects.Remove(gameObject);
        inactiveObjects.Add(gameObject);
    }
    #endregion
    
    #region Coroutines
    private IEnumerator cleanupRoutine() 
    {
    	WaitForSeconds cleanupTimer = new WaitForSeconds(cleanupTime);
    	while (true) 
    	{
    		if(inactiveObjects.Count > maxObjectCount) 
    		{
    			inactiveObjects.RemoveAt(inactiveObjects.Count - 1);
    		}
    		yield return cleanupTimer;
    	}
    }
    #endregion
}
