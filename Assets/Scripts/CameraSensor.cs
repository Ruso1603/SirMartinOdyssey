using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSensor : MonoBehaviour
{
    public Transform camera;

    float timer;

    bool presence;

    // Start is called before the first frame update
    void Start()
    {
        camera.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            presence = false;
            timer = 0;
        }

        if(presence)
        {
            camera.gameObject.SetActive(true);
        }
        else
        {
            camera.gameObject.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        presence = true;
        timer = 0.1f;
    }


    void OnTriggerStay(Collider other)
    {
        presence = true;
        timer = 0.1f;
    }
}
