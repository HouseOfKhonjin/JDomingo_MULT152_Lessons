using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // speed of movement/turning
    public float speed = 15.0f;
    //public float turnSpeed = 15.0f;

    private float horizontalInput;
    float verticalInput;
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Debug.Log(Time.deltaTime);
        //Vector3.forward --> (0, 0, 1)
        //rigidbody.velocity = Vector3.zero;
        //rigidbody.angularVelocity = Vector3.zero;
        //rigidbody.inertiaTensor = Vector3.zero;
        // (0, 0, 1) * Time.DeltaTime = (0, 0, 0.016)


        // if (verticalInput != 0 && horizontalInput != 0){
        //   rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        // }


        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput + Vector3.right * Time.deltaTime * speed * horizontalInput);
        // turns
        // transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
}
