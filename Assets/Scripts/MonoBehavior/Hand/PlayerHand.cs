using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{

    private StatusEffectController statusEffectController;
    public StatusEffectController StatusEffectController { get => statusEffectController; set => statusEffectController = value; }

    private HurtController hurtController;
    public HurtController HurtController { get => hurtController; set => hurtController = value; }


    private MotorController motorController;
   
    private FlickController flickController;

    [SerializeField]
    private string[] controlLayout; //0 - Horizontal Axis, 1 - Vertical Axis, 2 - Flick

    // Start is called before the first frame update
    void Start()
    {
        statusEffectController = transform.GetComponent<StatusEffectController>();
        hurtController = transform.GetComponent<HurtController>();
        motorController = transform.GetComponent<MotorController>();
        flickController = transform.GetComponent<FlickController>();
        
        motorController.FlickController = flickController;
        hurtController.MotorController = motorController;
    }

    // Update is called once per frame
    void Update()
    {
        motorController.Move(Input.GetAxis(controlLayout[0]), Input.GetAxis(controlLayout[1]));
        motorController.Turn();
        motorController.TriggerFlip(controlLayout[2]);
        
        

    }
}
