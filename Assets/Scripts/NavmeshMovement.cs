using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public bool pause;

    public bool gotoPoint;
    public Vector3 point;

    public bool gotoTarget;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(pause)
        {
            agent.isStopped = true;
            return;
        }
        else
        {
            agent.isStopped = false;
        }
        
        if (gotoPoint)
        {
            Debug.Log("Goto point");
            agent.SetDestination(point);
            gotoPoint = false;
        }

        if(gotoTarget)
        {
            Debug.Log("Goto target");
            agent.SetDestination(target.position);
            gotoTarget = false;

        }

        float speed;

        speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);


    }
}
