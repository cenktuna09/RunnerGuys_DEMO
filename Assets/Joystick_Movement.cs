using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick_Movement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public RectTransform pad;
    public RectTransform stick;
    public Transform player;
    Vector3 move;
    public float moveClamp;
    public float moveSpeed;
    bool walking;
    float releaseTime;
    private bool detected;

    public void OnDrag(PointerEventData eventData)
    {
        stick.position = eventData.position;
        stick.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.3f);


        move = new Vector3(stick.localPosition.x, 0, stick.localPosition.y).normalized;

        if (!walking)
        {
            walking = true;
            player.GetComponent<Animator>().SetBool("Move Forward", true);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pad.gameObject.SetActive(true);
        StartCoroutine("PlayerMove");
        pad.position = eventData.position;


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        /*
         * 
         
        if(releaseTime < 0.2f)
        {
            player.GetChild(0).GetComponent<Animator>().Play("jump-up");
            player.GetComponent<Rigidbody>().AddForce(0f, 50f, 0f,ForceMode.Impulse);
        }
        */
        stick.localPosition = Vector3.zero;
        move = Vector3.zero;
        StopCoroutine("PlayerMove");

        walking = false;
        player.GetComponent<Animator>().SetBool("Move Forward", false);
        pad.gameObject.SetActive(false);
    }

    IEnumerator PlayerMove()
    {
        releaseTime = 0;

        while (true)
        {
            Debug.Log(move.normalized);
            releaseTime += Time.deltaTime;


            player.Translate(move * moveSpeed * Time.deltaTime, Space.World);
            if (move != Vector3.zero)

               player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);

            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(player.GetChild(0).position, player.GetChild(0).forward);
        Debug.DrawRay(player.GetChild(0).position, player.GetChild(0).forward * 20f, Color.red);
        if (Physics.Raycast(ray, out hit, 20f))
        {
            detected = false;
            if (hit.transform.gameObject.CompareTag("Skeleton") && detected == false)
            {
                detected = true;
                player.GetComponent<Animator>().SetBool("Move Forward", false);
                player.GetComponent<Animator>().SetBool("Spin Attack", true);
            }
            
        }

        
           
    }
}
