using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MotorController : MonoBehaviour
{
    private AudioSource soundSource;
    [SerializeField] private AudioClip flickSound;
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
        soundSource = GetComponent<AudioSource>();
        rb = transform.GetComponent<Rigidbody>();
        StartCoroutine(ItemScan());
    }

    void Update()
    {
        Move(Input.GetAxis(controlLayout[0]), Input.GetAxis(controlLayout[1]));
        TriggerFlick(controlLayout[2]);
        Turn();
    }

    private void Move(float horAxis, float verAxis)
    {
        if (canMove)
        {
            rb.velocity = new Vector3(horAxis * speedData.Speed, 0, verAxis * speedData.Speed);
        }
        else
        {

        }
    }

    private void Turn()
    {
        if (NearestItem)
        {
            transform.GetChild(0).transform.rotation = Quaternion.Lerp(transform.GetChild(0).transform.rotation, Quaternion.LookRotation(nearestItem.transform.position - transform.position, Vector3.up), 5f * Time.deltaTime);
        }
        else
        {
            if(canMove)
            transform.GetChild(0).transform.rotation = Quaternion.Lerp(transform.GetChild(0).transform.rotation, Quaternion.LookRotation(rb.velocity.normalized, Vector3.up), 5f * Time.deltaTime);
        }
    }

    private IEnumerator ItemScan()
    {
        while (true)
        {
        float nearestDistance = float.MaxValue;
            Collider[] objectsNear = Physics.OverlapSphere(transform.position, 4f, flickableItemLayer, QueryTriggerInteraction.Ignore);
            if (objectsNear.Length >= 1)
            {
                for (int i = 0; i < objectsNear.Length; i++)
                {
                    if ((transform.position - objectsNear[i].transform.position).sqrMagnitude < nearestDistance)
                    {
                        nearestDistance = (transform.position - objectsNear[i].transform.position).sqrMagnitude;
                        nearestItem = objectsNear[i].gameObject;
                    }
                }
            }
            else
            {
                nearestItem = null;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void TriggerFlick(string flickInput)
    {
        if (Input.GetButton(flickInput))
        {
            playerHand.FlickController.ChargeFlick();
        }
        else if (Input.GetButtonUp(flickInput))
        {
            soundSource.clip = flickSound;
            soundSource.Play();
            playerHand.FlickController.Flick(nearestItem);
            nearestItem = null;
        }
    }
}
