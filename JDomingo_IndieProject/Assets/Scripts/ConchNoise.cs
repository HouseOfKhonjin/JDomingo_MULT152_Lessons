using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConchNoise : MonoBehaviour
{
    public PlayerInventory NewItemSelected;
    public bool HeardNoise;
    public bool hasEntered;
    public bool noiseDisabled;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Conch"))
        {
            Debug.Log("Enter Trigger");
            hasEntered = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Conch"))
        {
            Debug.Log("Exit Trigger");
            hasEntered = false;
        }

    }

    void Noise()
    {
        Debug.Log(noiseDisabled);
        if (noiseDisabled == false)
        {
            Debug.Log("OCEAN NOISES");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (NewItemSelected.conchShell_item.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && HeardNoise == false)
            {
                Debug.Log("calling invoke rep");
                InvokeRepeating("Noise", 2.5f, 4.0f);
                HeardNoise = true;
            }
        }

        else
        {
            return;
        }
    }
}
