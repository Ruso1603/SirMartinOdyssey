using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAttackReaction : MonoBehaviour
{
    public Animator animator;

    public bool fall;

    public float fallDuration = 2;

    private float fallTimer;

    // Start is called before the first frame update
    void Start()
    {
        fallTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fall)
        {
            // Se inicia la caida

            animator.SetTrigger("TriggerFall");

            fallTimer = fallDuration;

            fall= false;
        }

        if (fallTimer > 0)
        {
            fallTimer = fallTimer - Time.deltaTime;

            if (fallTimer <= 0)
            {
                // Se levanta

                animator.SetTrigger("TriggerFallEnd");

            }
        }


    }

    public void UpdateNow()
    {
        Update();
    }
}

