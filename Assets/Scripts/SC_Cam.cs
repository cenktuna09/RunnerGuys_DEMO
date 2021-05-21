using UnityEngine;

public class SC_Cam : MonoBehaviour
{
    public float smoothTime = 0.125f;
    public Transform target;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    GameObject player;
    private Rigidbody _body;
    private Rigidbody camRb;
    public float damping = 1;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        _body = player.GetComponent<Rigidbody>();
        camRb = transform.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
         
        Vector3 desiredPosition = _body.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(camRb.position, desiredPosition, ref velocity,damping);
        camRb.position = smoothedPosition;
        // Define a target position above and behind the target transform
        //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5.51f, -4.16f));
        // Smoothly move the camera towards that target position
        // transform.position = target.position + offset;
        camRb.MovePosition(desiredPosition);
        // transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z-5.16f);
        


       
    }

    void OnTriggerEnter(Collider other)
    {
       
    }
}
