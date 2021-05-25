using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStick : MonoBehaviour
{
    private float rotationsPerMinute = 20f;
    private float forwardStrength = 115f;

    private Rigidbody stickRb;
    Vector3 m_EulerAngleVelocity;
    // Start is called before the first frame update
    void Start()
    {
        stickRb = transform.gameObject.GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 150, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        stickRb.MoveRotation(stickRb.rotation * deltaRotation);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<Rigidbody>().AddForce(0,0,0.5f,ForceMode.Impulse);
            
            //Debug.Log(forwardForce);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
