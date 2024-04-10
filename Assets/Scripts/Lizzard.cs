using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizzard : MonoBehaviour
{
    public Animator animator;
    public NavmeshFollow follow;
    public NavmeshMovement movement;
    public DashAttack dashAttack;
    public FireAttack fireAttack;
    public Sensor dashAttackSensor;
    public Sensor fireAttackSensor;
    public Sensor damageSensor;
    public FallAttackReaction fallAttackReaction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Movement") == false)
        {
            // Como no estamos en el estado movement quiere decir que el animator
            // está haciendo alguna acción y tenemos que esperar a que termine
            return;
        }

        if (animator.IsInTransition(0))
        {
            // Como estamos transicionando quiere decir que el animator
            // está haciendo alguna acción y tenemos que esperar a que termine
            return;
        }

        // Ponemos el lizard en marcha
        follow.pause = false;
        movement.pause = false;

        if(damageSensor.presence)
        {
            // Paramos el lizzard
            follow.pause = true;
            movement.pause = true;

            fallAttackReaction.fall = true;
            fallAttackReaction.UpdateNow();
        }
        else if(dashAttackSensor.presence)
        {
            // Paramos el lizzard
            follow.pause = true;
            movement.pause = true;

            // Arrancamos el ataque
            dashAttack.attack = true;
            dashAttack.UpdateNow();

        }
        else if(fireAttackSensor.presence)
        {
            // Paramos el lizzard
            follow.pause = true;
            movement.pause = true;

            // Arrancamos el ataque
            fireAttack.attack = true;
            fireAttack.UpdateNow();

        }
    }
}
