using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtController : MonoBehaviour
{

    [SerializeField]
    private float currentHurt = 0;
    public float CurrentHurt { get => currentHurt; set => currentHurt = value; }
    private Rigidbody rb;
    private PlayerHand playerHand;
    public PlayerHand PlayerHand { get => playerHand; set => playerHand = value; }

    [SerializeField]
    private HurtData hurtData;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    
    public void OnHurt(float damage, Transform hitterPosition)
    {
        Vector3 flyDirection = Vector3.Normalize(transform.position - hitterPosition.position) * ((currentHurt / 10) + 20);
        rb.AddForce(flyDirection, ForceMode.Impulse);
        
        playerHand.MotorController.CanMove = false;
        
        currentHurt += damage;
        
        
        Invoke("HurtEnd", 1.5f);
    }
    private void HurtEnd()
    {
        rb.velocity = Vector3.zero;
        playerHand.MotorController.CanMove = true;
    }
}
