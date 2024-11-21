using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool heardNoise;
    public GameObject player;
    Rigidbody fishes;
    public float speed = 0.05f;
    public float rotationSpeed = 0.05f;
    public float distance = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(heardNoise == true)
        {
            Follow();
        }
    }

    void Follow()
    {
        //Vector3 seekDirection = (player.transform.position - transform.position).normalized;
        //fishes.AddForce(seekDirection * speed * Time.deltaTime);
        if(DistanceToPlayer() >= distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);    
        }
        // Determine which direction to rotate towards
        Vector3 targetDirection = player.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    float DistanceToPlayer()
    {
        return(player.transform.position - transform.position).magnitude;
    }
}
