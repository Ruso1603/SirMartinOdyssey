using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
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
        if(animator.GetCurrentAnimatorStateInfo(1).IsName("Upper Body.Attack"))
        {
            attackArea.gameObject.SetActive(true);
        }
        else
        {
            attackArea.gameObject.SetActive(false);
        }

        if (attack)
        {
            animator.SetTrigger("TriggerAttack");
        }

        attack = false;
    }
}
