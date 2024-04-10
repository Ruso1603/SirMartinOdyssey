using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    public Transform attackArea;
    public Animator animator;
    public bool attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.DashAttack"))
        {
            attackArea.gameObject.SetActive(true);
        }
        else
        {
            attackArea.gameObject.SetActive(false);
        }

        if (attack)
        {
            animator.SetTrigger("TriggerDash");
            attack = false;
        }



    }

    public void UpdateNow()
    {
        Update();
    }
}
