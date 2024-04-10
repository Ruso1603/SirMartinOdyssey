using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int body;

    public Transform body01;
    public Transform body02;
    public Transform body03;

    public int sword;

    public Transform sword01;
    public Transform sword02;
    public Transform sword03;

    public int shield;

    public Transform shield01;
    public Transform shield02;
    public Transform shield03;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        body01.gameObject.SetActive(false);
        body02.gameObject.SetActive(false);
        body03.gameObject.SetActive(false);

        if (body == 0) { body01.gameObject.SetActive(true); }
        else if (body == 1) { body02.gameObject.SetActive(true); }
        else if (body == 2) { body03.gameObject.SetActive(true); }

        sword01.gameObject.SetActive(false);
        sword02.gameObject.SetActive(false);
        sword03.gameObject.SetActive(false);

        if (sword == 0) { sword01.gameObject.SetActive(true); }
        else if (sword == 1) { sword02.gameObject.SetActive(true); }
        else if (sword == 2) { sword03.gameObject.SetActive(true); }

        shield01.gameObject.SetActive(false);
        shield02.gameObject.SetActive(false);
        shield03.gameObject.SetActive(false);

        if (shield == 0) { shield01.gameObject.SetActive(true); }
        else if (shield == 1) { shield02.gameObject.SetActive(true); }
        else if (shield == 2) { shield03.gameObject.SetActive(true); }

    }
}
