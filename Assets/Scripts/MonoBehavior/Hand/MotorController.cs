using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MotorController : MonoBehaviour
{
    [SerializeField]
    private SpeedData speedData;
    private GameObject nearestItem;
    public GameObject NearestItem { get => nearestItem; }
    [SerializeField]
    private LayerMask flickableItemLayer;
    [SerializeField]
    private Vector3 defaultPosition;
    private FlickController flickController;
    public FlickController FlickController { set => flickController = value; }
    [SerializeField]
    private bool canMove;
    public bool CanMove { set => canMove = value; }
    private Rigidbody rb;
    
    
    
    



    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rb = transform.GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void Move(float horAxis, float verAxis)
    {
        
        if (canMove)
        {
            transform.Translate(horAxis * speedData.Speed * Time.deltaTime, 0, verAxis * speedData.Speed * Time.deltaTime);
        }
        

        
        
    }

    public void Turn()
    {
        float nearestDistance = 1000f;
        Collider[] objectsNear = Physics.OverlapSphere(transform.position, 4f, flickableItemLayer, QueryTriggerInteraction.Ignore);


        


        if (objectsNear.Length >= 1)
        {
            
            
            for (int i = 0; i < objectsNear.Length; i++)
            {
                if(Vector3.Distance(transform.position, objectsNear[i].transform.position) < nearestDistance)
                {
                    nearestDistance = Vector3.Distance(transform.position, objectsNear[i].transform.position);
                    nearestItem = objectsNear[i].gameObject;
                }
            }
            
            transform.GetChild(0).transform.rotation = Quaternion.Lerp(transform.GetChild(0).transform.rotation, Quaternion.LookRotation(nearestItem.transform.position - transform.position, Vector3.up), 5f * Time.deltaTime);
        }
        else
        {
            transform.GetChild(0).transform.rotation = Quaternion.Lerp(transform.GetChild(0).transform.rotation, Quaternion.LookRotation(defaultPosition, Vector3.up), 5f * Time.deltaTime);
        }
        
    }

    public void TriggerFlip(string flickInput)
    {
        
        if( nearestItem != null && Vector3.Distance(nearestItem.transform.position, transform.position) < 3f)
        {

            if (Input.GetButton(flickInput))
            {
                if(flickController.CurrentFlickForce < flickController.FlickData.MaxFlickForce)
                {
                    flickController.CurrentFlickForce += flickController.FlickData.ForceIncreaseSpeed * Time.deltaTime;
                }
                else
                {
                    flickController.CurrentFlickForce = flickController.FlickData.MaxFlickForce;
                }
            }
            else if (Input.GetButtonUp(flickInput))
            {
                Vector3 flickDirection = (Vector3.Normalize(nearestItem.transform.position - transform.position)) * (10f * flickController.CurrentFlickForce);
                nearestItem.GetComponent<Rigidbody>().AddForce(flickDirection, ForceMode.Impulse);
                flickController.CurrentFlickForce = 0f;
                nearestItem.GetComponent<ItemBase>.OnFlick();
                nearestItem = null;
            }
            
        }
        
    }
}
