using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Animator animator;
    public Sensor sensor;

    public bool isUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sensor.presence)
        {
            animator.SetBool("BoolUp", true);

            isUp = true;
        }
    }
}
