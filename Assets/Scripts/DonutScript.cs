using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(transform.parent.position.x > 0f)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-700f, 0, 0,ForceMode.Force);
                Debug.Log("YESYESYES");
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(700f, 0, 0,ForceMode.Force);
            }
        }
    }
}
