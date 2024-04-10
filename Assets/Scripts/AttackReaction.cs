using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackReaction : MonoBehaviour
{
    public Animator animator;

    public bool react;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(react)
        {
            animator.SetTrigger("TriggerHit");
        }

        react = false;
    }
}
