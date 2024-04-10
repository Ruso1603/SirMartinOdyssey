using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavmeshFollow : MonoBehaviour
{
    public NavmeshMovement movement;

    public bool pause;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(pause)
        {
            return;
        }

        timer = timer - Time.deltaTime;

        if(timer < 0)
        {
            Debug.Log("Follow");
            movement.gotoTarget = true;
            timer = 3;
        }
    }
}
