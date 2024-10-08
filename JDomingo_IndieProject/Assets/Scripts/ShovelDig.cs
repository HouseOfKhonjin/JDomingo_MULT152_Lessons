using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelDig : MonoBehaviour
{
    public PlayerInventory NewItemSelected;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NewItemSelected.shovel_item.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("DIGGED!");
            }
        }

        else
        {
            return;
        }
    }
}
