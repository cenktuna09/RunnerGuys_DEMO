using UnityEngine;
using UnityEngine.AI;
public class AI_Movement : MonoBehaviour
{
    public Transform finalDestination;
    private NavMeshAgent playerAgent;
    private Rigidbody playerRb;
    Vector3 respawnPoint;
    private bool isPhysical;
    private float knockbackCooldown = 0f;
    private float knockbackTime = 1f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
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
                
                playerAgent.enabled = true;
                GetComponent<Rigidbody>().isKinematic = true;

                if(playerAgent.isOnNavMesh == false)
                {
                    playerAgent.enabled = false;
                    transform.position = respawnPoint;
                    playerAgent.enabled = true;
                    playerAgent.SetDestination(finalDestination.position);
                    playerRb.useGravity = false;
                }

                playerAgent.destination = finalDestination.position;
                isPhysical = false;
                knockbackCooldown = 0;
            }
            else
            {
                
            }

            /*

            Vector3 direction = transform.TransformDirection(finalDestination.position);
            float distance = Vector3.Distance(finalDestination.position, transform.position);

            if(distance > 0.1f)
            {
                Vector3 movement = transform.forward * Time.deltaTime * 1f;
                playerAgent.Move(movement);
            }
            */
        }


}
    private void FixedUpdate()
    {
        
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

            playerAgent.enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            isPhysical = true;
            playerRb.AddForce(0, 0, 5f, ForceMode.Impulse);

        }
    }
}
