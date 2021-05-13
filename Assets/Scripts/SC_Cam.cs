using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Cam : MonoBehaviour
{
    public float smoothTime = 0.125f;
    public Transform target;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    GameObject player;
    private Rigidbody _body;

    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
        _body = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = _body.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothTime);
        transform.position = smoothedPosition;
        // Define a target position above and behind the target transform
        //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5.51f, -4.16f));
        // Smoothly move the camera towards that target position
        //transform.position = target.position + offset;
        //transform.LookAt(target);
        // transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z-5.16f);
    }

    void OnTriggerEnter(Collider other)
    {
       
    }
}
