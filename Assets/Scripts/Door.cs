using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public Transform physicsBlocker;
    public Transform navMeshBlocker;

    public bool opened;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // También se puede hacer con
        // if(animator.GetAnimatorCurrentState(0).IsName("Base Layer.Opened"))

        if(opened)
        {
            physicsBlocker.gameObject.SetActive(false);
            navMeshBlocker.gameObject.SetActive(false);
        }
        else
        {
            physicsBlocker.gameObject.SetActive(true);
            navMeshBlocker.gameObject.SetActive(true);
        }

        animator.SetBool("BoolOpened", opened);
    }
}
