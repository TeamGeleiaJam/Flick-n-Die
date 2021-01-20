using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{

    private StatusEffectController statusEffectController;
    public StatusEffectController StatusEffectController { get => statusEffectController; set => statusEffectController = value; }

    private HurtController hurtController;
    public HurtController HurtController { get => hurtController; set => hurtController = value; }


    private MotorController motorController ;
    public MotorController MotorController { get => motorController; set => motorController = value; }
   
    private FlickController flickController;
    public FlickController FlickController { get => flickController; set => flickController = value; }

    
    

    // Start is called before the first frame update
    void Start()
    {
        statusEffectController = transform.GetComponent<StatusEffectController>();
        hurtController = transform.GetComponent<HurtController>();
        motorController = transform.GetComponent<MotorController>();
        flickController = transform.GetComponent<FlickController>();


        motorController.PlayerHand = this;
        hurtController.PlayerHand = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        

    }
}
