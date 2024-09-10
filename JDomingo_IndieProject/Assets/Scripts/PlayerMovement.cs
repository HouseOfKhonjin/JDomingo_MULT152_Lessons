using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // speed of movement/turning
    public float speed = 15.0f;
    //public float turnSpeed = 15.0f;

    public Transform orientation;

    private float horizontalInput;
    float verticalInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Debug.Log(Time.deltaTime);
        //Vector3.forward --> (0, 0, 1)
        // (0, 0, 1) * Time.DeltaTime = (0, 0, 0.016)
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // turns
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
}
