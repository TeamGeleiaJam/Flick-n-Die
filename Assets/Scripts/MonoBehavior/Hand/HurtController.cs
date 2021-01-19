using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtController : MonoBehaviour
{

    [SerializeField]
    private float currentHurt;
    public float CurrentHurt { get => currentHurt; set => currentHurt = value; }
    private Rigidbody rb;
    private MotorController motorController;
    public MotorController MotorController { set => motorController = value; }

    [SerializeField]
    private HurtData hurtData;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHurt(float damage, Transform hitterPosition)
    {
        Vector3 flyDirection = Vector3.Normalize(transform.position - hitterPosition.position) * ((currentHurt / 10) + 20);
        rb.AddForce(flyDirection, ForceMode.Impulse);
        
        motorController.CanMove = false;
        if(currentHurt < 300)
        {
            currentHurt += damage;
        }
        else
        {
            currentHurt = 300f;
        }
        motorController.CanMove = false;
        Invoke("HurtEnd", 1.5f);
    }
    private void HurtEnd()
    {
        rb.velocity = Vector3.zero;
        motorController.CanMove = true;
    }
}
