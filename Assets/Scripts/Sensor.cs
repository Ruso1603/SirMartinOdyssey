using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool presence;

    public bool entered;
    public bool exited;

    float timer;

    bool previousPresence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if(timer < 0)
        {
            presence = false;
            timer = 0;
        }

        if(previousPresence == false && presence == true)
        {
            entered = true;
        }
        else
        {
            entered = false;
        }

        if(previousPresence == true && presence == false)
        {
            exited = true;
        }
        else
        {
            exited = false;
        }

        previousPresence = presence;
    }

    void OnTriggerEnter(Collider other)
    {
        presence = true;
        timer = 0.1f;
    }


    void OnTriggerStay(Collider other)
    {
        presence = true;
        timer = 0.1f;
    }
}
