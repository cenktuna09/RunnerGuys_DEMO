using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Platform : MonoBehaviour
{
    private float rotationsPerMinute = 5f;
    private float maxForce = -115f;

    private bool leftRotate;
    private bool rightRotate;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.gameObject.CompareTag("RotateObsLeft"))
        {
            leftRotate = true;
        }
        if (transform.gameObject.CompareTag("RotateObsRight"))
        {
            rightRotate = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(leftRotate == true)
        {
            transform.Rotate(0, 0, 6f * rotationsPerMinute * Time.deltaTime);
        }
        if (rightRotate == true)
        {
            transform.Rotate(0, 0, -6f * rotationsPerMinute * Time.deltaTime);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        /*
         
        if(collision.gameObject.CompareTag("Player"))
        {
            
            
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            var speed = rb.velocity.normalized.magnitude;
            Debug.Log(speed);
            
           // rb.add
            //rb.velocity = Vector3.ClampMagnitude(new Vector3(rb.velocity.x,0,0), 155);



        }
        */
    }
}
