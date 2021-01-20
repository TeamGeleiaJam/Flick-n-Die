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
    private PlayerHand playerHand;
    public PlayerHand PlayerHand { get => playerHand; set => playerHand = value; } 
    [SerializeField]
    private bool canMove;
    public bool CanMove { get => canMove; set => canMove = value; }
    private Rigidbody rb;
    [SerializeField]
    private string[] controlLayout; //0 - Horizontal Axis, 1 - Vertical Axis, 2 - Flick


    void Start()
    {
        canMove = true;
        rb = transform.GetComponent<Rigidbody>();
        StartCoroutine(Turn());
    }

    void Update()
    {
        Move(Input.GetAxis(controlLayout[0]), Input.GetAxis(controlLayout[1]));
        TriggerFlick(controlLayout[2]);

    }

    public void Move(float horAxis, float verAxis)
    {
        if (canMove)
        {
            transform.Translate(horAxis * speedData.Speed * Time.deltaTime, 0, verAxis * speedData.Speed * Time.deltaTime);
        }

    }

    private IEnumerator Turn()
    {
        float nearestDistance = 1000f;
        Collider[] objectsNear = Physics.OverlapSphere(transform.position, 4f, flickableItemLayer, QueryTriggerInteraction.Ignore);

        if (objectsNear.Length >= 1)
        {
            
            
            for (int i = 0; i < objectsNear.Length; i++)
            {
                if((transform.position - objectsNear[i].transform.position).sqrMagnitude < nearestDistance)
                {
                    nearestDistance = (transform.position - objectsNear[i].transform.position).sqrMagnitude;
                    nearestItem = objectsNear[i].gameObject;
                }
            }
            
            transform.GetChild(0).transform.rotation = Quaternion.Lerp(transform.GetChild(0).transform.rotation, Quaternion.LookRotation(nearestItem.transform.position - transform.position, Vector3.up), 5f * Time.deltaTime);
        }
        else
        {
            transform.GetChild(0).transform.rotation = Quaternion.Lerp(transform.GetChild(0).transform.rotation, Quaternion.LookRotation(defaultPosition, Vector3.up), 5f * Time.deltaTime);
        }
        yield return new WaitForSeconds(0.2f);
    }

    public void TriggerFlick(string flickInput)
    {
        
        if( nearestItem != null && (nearestItem.transform.position - transform.position).sqrMagnitude < 9f)
        {

            if (Input.GetButton(flickInput))
            {
                playerHand.FlickController.ChargeFlick();
            }
            else if (Input.GetButtonUp(flickInput))
            {
                playerHand.FlickController.Flick(nearestItem);
                nearestItem = null;
            }
        }
    }
}
