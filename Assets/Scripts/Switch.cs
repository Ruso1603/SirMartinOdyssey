using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Animator animator;

    public Sensor interactionSensor;

    public bool on;
    public bool switchedOn;
    public bool switchedOff;


    float cooldown;

    bool previousOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0)
        {
            cooldown = cooldown - Time.deltaTime;
        }

        if(interactionSensor.presence && cooldown <= 0)
        {
            if(on)
            {
                on = false;
            }
            else
            {
                on = true;
            }

            cooldown = 2;

        }

        animator.SetBool("BoolOn", on);

        if(on == true && previousOn == false)
        {
            switchedOn = true;
        }
        else
        {
            switchedOn = false;
        }

        if(on == false && previousOn == true)
        {
            switchedOff = true;
        }
        else
        {
            switchedOff = false;
        }

        previousOn = on;


    }
}
