using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;

    public Transform player;
    public Transform orientation;
    public Transform target;
    public float xRotation;
    public float yRotation;
    public float mouseX;
    public float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        xRotation = 0f;
        yRotation = 0f;
        mouseX = 0f;
        mouseY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // gets the mouse inputs
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 

        player.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        //Debug.Log(mouseY);
        //transform.Rotate(xRotation, 0, 0, Space.Self);
        //transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //transform.LookAt(target, Vector3.left);
    }
}
