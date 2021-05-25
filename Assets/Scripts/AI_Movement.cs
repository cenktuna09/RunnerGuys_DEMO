using UnityEngine;
using UnityEngine.AI;
public class AI_Movement : MonoBehaviour
{
    public Transform finalDestination;
    private NavMeshAgent playerAgent;
    private Rigidbody playerRb;
    private BoxCollider playerCollider;
    Vector3 respawnPoint;
    private bool isPhysical;
    private float knockbackCooldown = 0f;
    private float knockbackTime = 1.5f;
    private Animator animator;
    private bool isHit;
    private bool rotateLeft;
    private bool rotateRight;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = transform.gameObject.GetComponent<BoxCollider>();
        animator = transform.gameObject.GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;   //new Vector3(transform.position.x, transform.position.y, transform.position.z);
        playerAgent = GetComponent<NavMeshAgent>();
        playerAgent.SetDestination(finalDestination.position);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPhysical == true)
        {
            
            playerAgent.enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            // Add the time since the last Update
            knockbackCooldown += Time.deltaTime;
            if (knockbackCooldown > knockbackTime)
            {
                if(playerAgent.isOnNavMesh == false)
                {
                    
                    transform.position = respawnPoint;
                    playerAgent.enabled = true;
                    playerAgent.SetDestination(finalDestination.position);
                    playerRb.useGravity = false;
                }

                playerAgent.enabled = true;
                GetComponent<Rigidbody>().isKinematic = true;

                playerCollider.isTrigger = true;
                playerAgent.destination = finalDestination.position;
                isPhysical = false;
                knockbackCooldown = 0;
            }
            else
            {
                
            }
        }


}
    private void FixedUpdate()
    {
        if(isHit == true)
        {
            //playerRb.AddForce(0, 0, -100f,ForceMode.Force);
            Debug.Log("VURDU");
            isHit = false;
        }

        if(rotateLeft)
        {
            playerRb.isKinematic = false;
            playerRb.AddForce(-150f, 0, 0);
          //  playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, 20f);
          
        }

        if(rotateRight)
        {
            playerRb.isKinematic = false;
            playerRb.AddForce(150f, 0, 0);
          //  playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, 20f);
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obs"))
        {
            transform.position = respawnPoint;
            playerAgent.SetDestination(finalDestination.position);

        }

        if (other.gameObject.CompareTag("Finishline"))
        {
            playerAgent.isStopped = true;
            animator.SetBool("idle", true);

        }

        if(other.gameObject.CompareTag("Donut"))
        {

            playerRb.useGravity = true;
            isPhysical = true;
            if (other.gameObject.transform.parent.position.x < 0)
            {
                playerRb.AddForce(1200f, 0, 0, ForceMode.Force);
                Debug.Log("oldu");
            }
            else
            {
                playerRb.AddForce(-1200f, 0, 0, ForceMode.Force);
                Debug.Log("oldu");
            }
            
        }

        if (other.gameObject.CompareTag("RotatorStick"))
        {

            playerCollider.isTrigger = false;
            GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 0.5f, ForceMode.Impulse);
            //playerAgent.enabled = true;
            isHit = true;
            //isPhysical = true;
            
            playerCollider.isTrigger = true;

        }


    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("RotateObsLeft"))
        {
            rotateLeft = true;

        }
        if (other.gameObject.CompareTag("RotateObsRight"))
        {
            rotateRight = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RotateObsLeft"))
        {
            rotateLeft = false;
            playerRb.isKinematic = true;

        }
        if (other.gameObject.CompareTag("RotateObsRight"))
        {
            rotateRight = false;
            playerRb.isKinematic = true;

        }
    }
}
