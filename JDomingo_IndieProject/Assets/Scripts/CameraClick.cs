using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClick : MonoBehaviour
{
    public PlayerInventory NewItemSelected;
    public bool hasEntered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Camera"))
        {
            Debug.Log("Enter Trigger");
            hasEntered = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Camera"))
        {
            Debug.Log("Exit Trigger");
            hasEntered = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (NewItemSelected.camera_item.activeSelf == true)
        {
            Debug.Log(Input.GetKeyDown(KeyCode.Mouse0) + ", " + hasEntered);

            if (Input.GetKeyDown(KeyCode.Mouse0) && hasEntered)
            {
                Debug.Log("CLICK!");
            }
        }

        else
        {
            return;
        }
    }
}
