using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public Sensor interactionSensor;
    public GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        if(interactionSensor.presence)
        {
            if(particlePrefab != null)
            {
                GameObject.Instantiate(particlePrefab, transform.position, transform.rotation);
            }

            GameObject.Destroy(gameObject);
        }
    }
}
