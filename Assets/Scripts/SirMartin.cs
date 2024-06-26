using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirMartin : MonoBehaviour
{
    public PhysicsMovement movement;
    public Attack attack;
    public Block block;
    public AttackReaction attackReaction;
    public DieReaction dieReaction;
    public Inventory inventory;
    public Stats stats;
    public Sensor damageSensor;
    public Animator animator;
    public Spawner magicSpawner;
    public Spawner powerSpawner;
    public Transform smoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        movement.forward = Input.GetAxis("Vertical");
        movement.lateral = Input.GetAxis("Horizontal");

        if(inventory.body == 1)
        {
            movement.speed = 12;
            smoke.gameObject.SetActive(true);
        }
        else
        {
            movement.speed = 6;
            smoke.gameObject.SetActive(false);
        }

        if(damageSensor.entered)
        {
            stats.hearts = stats.hearts - 1;

            if(stats.hearts <= 0)
            {
                dieReaction.react = true;
            }
            else
            {
                attackReaction.react = true;
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Upper Body.Idle") == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(inventory.sword == 1)
            {
                powerSpawner.spawn = true;
            }
            else if(inventory.sword == 2)
            {
                magicSpawner.spawn = true;
            }

            attack.attack = true;
        }

    }

}
