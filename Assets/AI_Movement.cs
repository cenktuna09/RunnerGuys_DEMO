using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;   //new Vector3(transform.position.x, transform.position.y, transform.position.z);
        playerAgent = GetComponent<NavMeshAgent>();
        playerAgent.destination = finalDestination.position;

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
                Debug.Log("olduvePHYSICCC");
                playerAgent.enabled = true;
                GetComponent<Rigidbody>().isKinematic = true;
                playerAgent.destination = finalDestination.position;
                if(playerAgent.isOnNavMesh == false)
                {
                    transform.position = respawnPoint;
                    playerAgent.enabled = false;
                    playerAgent.enabled = true;
                    playerAgent.destination = finalDestination.position;
                    
                }


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obs"))
        {
            transform.position = respawnPoint;

        }

        if (other.gameObject.CompareTag("Finishline"))
        {
            playerAgent.isStopped = true;

        }

        if(other.gameObject.CompareTag("Donut"))
        {
            
             
            isPhysical = true;
            if (other.gameObject.transform.parent.position.x < 0)
            {
                playerRb.AddForce(900f, 0, 0, ForceMode.Force);
                Debug.Log("oldu");
            }
            else
            {
                playerRb.AddForce(-900f, 0, 0, ForceMode.Force);
                Debug.Log("oldu");
            }
            
        }
    }
}
