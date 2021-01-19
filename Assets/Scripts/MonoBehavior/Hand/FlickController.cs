using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickController : MonoBehaviour
{
    [SerializeField]
    private float currentFlickForce;
    public float CurrentFlickForce { get => currentFlickForce; set => currentFlickForce = value; }

    [SerializeField]
    private FlickData flickData;
    public FlickData FlickData { get => flickData; set => flickData = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
