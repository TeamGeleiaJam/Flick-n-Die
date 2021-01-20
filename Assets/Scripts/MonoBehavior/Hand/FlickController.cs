using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickController : MonoBehaviour
{
    [SerializeField]
    private float currentFlickForce = 0;
    public float CurrentFlickForce { get => currentFlickForce; set => currentFlickForce = value; }

    private PlayerHand playerHand;

    public PlayerHand PlayerHand { get => playerHand; set => playerHand = value; }

    [SerializeField]
    private FlickData flickData;
    public FlickData FlickData { get => flickData; set => flickData = value; }

    public void ChargeFlick()
    {
        if (playerHand.FlickController.CurrentFlickForce < playerHand.FlickController.FlickData.MaxFlickForce)
        {
            playerHand.FlickController.CurrentFlickForce += playerHand.FlickController.FlickData.ForceIncreaseSpeed * Time.deltaTime;
        }
        else
        {
            playerHand.FlickController.CurrentFlickForce = playerHand.FlickController.FlickData.MaxFlickForce;
        }
    }

    public void Flick(GameObject item)
    {
        if (!item)
        {
            playerHand.FlickController.CurrentFlickForce = 0f;
            return;
        }
        Vector3 flickDirection = (Vector3.Normalize(item.transform.position - transform.position)) * (10f * playerHand.FlickController.CurrentFlickForce);
        Rigidbody itemRb = item.GetComponent<Rigidbody>();
        itemRb.isKinematic = false;
        itemRb.AddForce(flickDirection, ForceMode.Impulse);
        item.GetComponent<Rigidbody>().AddForce(flickDirection, ForceMode.Impulse);

        playerHand.FlickController.CurrentFlickForce = 0f;

        item.GetComponent<ItemBase>().OnFlick();
    }
}
