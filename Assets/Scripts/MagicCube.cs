using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCube : MonoBehaviour
{
    public Sensor sensor;
    public Stats stats;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        float random;

        random = UnityEngine.Random.value;

        animator.SetFloat("Cycle", random);
    }

    // Update is called once per frame
    void Update()
    {
        if(sensor.presence)
        {
            stats.cubes = stats.cubes + 1;
            GameObject.Destroy(gameObject);
        }
    }
}
