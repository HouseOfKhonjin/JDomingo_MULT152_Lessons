using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rbPlayer;
    public float speed = 10.0f;
    GameObject focalPoint;
    Renderer rendererPlay;
    // Start is called before the first frame update
    void Start()
    {
       rbPlayer = GetComponent<Rigidbody>();
       rendererPlay = GetComponent<Renderer>();
       focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float magnitude = forwardInput * speed * Time.deltaTime;
        rbPlayer.AddForce(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime, ForceMode.Force);

        if(forwardInput > 0)
        {
            rendererPlay.material.color = new Color(1.0f - forwardInput, 1.0f, 1.0f - forwardInput);
        }
        else
        {
            rendererPlay.material.color = new Color(1.0f + forwardInput, 1.0f, 1.0f + forwardInput);
        }
    }
}
