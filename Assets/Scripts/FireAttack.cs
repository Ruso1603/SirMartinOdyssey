using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public Transform attackArea;
    public ParticleSystem particles;
    public Animator animator;

    public bool attack;

    public float holdDuration = 2;
    public float fireDuration = 3;

    private float holdTimer;
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        holdTimer = 0;
        fireTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.FireProgress"))
        {
            attackArea.gameObject.SetActive(true);
        }
        else
        {
            attackArea.gameObject.SetActive(false);
        }


        if (attack)
        {
            // Se inicia el ataque

            animator.SetTrigger("TriggerFirePrepare");

            holdTimer = holdDuration;

            attack = false;
        }

        if(holdTimer > 0)
        {
            holdTimer = holdTimer - Time.deltaTime;

            if (holdTimer <= 0)
            {
                // Empieza a tirar fuego

                animator.SetTrigger("TriggerFireStart");
                particles.Play();

                fireTimer = fireDuration;

            }
        }

        if (fireTimer > 0)
        {
            fireTimer = fireTimer - Time.deltaTime;

            if (fireTimer <= 0)
            {
                // Deja de tirar fuego

                animator.SetTrigger("TriggerFireEnd");
                particles.Stop();
            }

        }


    }

    public void UpdateNow()
    {
        Update();
    }

}
