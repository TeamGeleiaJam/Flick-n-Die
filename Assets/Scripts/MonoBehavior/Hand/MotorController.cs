using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    [SerializeField]
    private SpeedData speedData;
    private GameObject nearestItem;
    [SerializeField]
    private LayerMask flickableItemLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Turn();
        if (Input.GetButtonDown("Fire1") && nearestItem != null && Vector3.Distance(nearestItem.transform.position, transform.position) < 3f)
        {
            TriggerFlip();
        }
    }

    public void Move()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");

        transform.Translate(horAxis * speedData.Speed * Time.deltaTime, 0, verAxis * speedData.Speed * Time.deltaTime);
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
            transform.GetChild(0).transform.LookAt(nearestItem.transform);
        }
        else
        {
            transform.GetChild(0).transform.rotation = Quaternion.Euler(0,0,0);
        }
        
    }

    public void TriggerFlip()
    {
        Vector3 flickDirection = (Vector3.Normalize(nearestItem.transform.position - transform.position)) * 12f;
        nearestItem.GetComponent<Rigidbody>().AddForce(flickDirection, ForceMode.Impulse);
        nearestItem = null;
    }
}
