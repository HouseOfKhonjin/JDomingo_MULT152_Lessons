using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelDig : MonoBehaviour
{
    public PlayerInventory NewItemSelected;
    public bool hasEntered;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Trigger");
        hasEntered = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit Trigger");
        hasEntered = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(NewItemSelected.shovel_item.activeSelf == true);
        if (NewItemSelected.shovel_item.activeSelf == true)
        {
            Debug.Log(Input.GetKeyDown(KeyCode.Mouse0) + ", " + hasEntered);
            
            if (Input.GetKeyDown(KeyCode.Mouse0) && hasEntered)
            {
                Destroy(gameObject);
                Debug.Log("DIGGED!");
            }
        }

        else
        {
            return;
        }
    }
}
