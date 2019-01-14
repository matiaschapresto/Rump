using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShipMovementScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 200;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.freezeRotation = true; // take manual control of rotation
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
            rb.freezeRotation = false; // resume physics control of rotation
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.freezeRotation = true; // take manual control of rotation
            transform.Rotate(Vector3.right *speed * Time.deltaTime);
            rb.freezeRotation = false; // resume physics control of rotation
        }


    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "LaunchPad" ){
            Destroy(gameObject);
        }
    }
}
