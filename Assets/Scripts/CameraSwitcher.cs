using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform camera1;
    public Transform camera2;
    public Transform camera3;

    // Start is called before the first frame update
    void Start()
    {
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
        camera3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
            camera3.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
            camera3.gameObject.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(false);
            camera3.gameObject.SetActive(true);
        }

    }
}
