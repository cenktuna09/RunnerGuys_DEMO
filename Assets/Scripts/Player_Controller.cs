using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private bool isClick;
    private Rigidbody rb;
    private float speed;
    private Vector2 mousePos;

    Vector3 move;
    float mouseX;
    float mouseY;
    Vector2 XandY;
    float speedX = 5f;
    float speedY = 10f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 7.5f;
        Application.targetFrameRate = 144;
        rb = transform.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = new Vector3 (0, 0, 0);
            
            isClick = true;
           
            
        }
       if(Input.GetMouseButtonUp(0))
        {
            isClick = false;
        }

        if (isClick == true)
        {
            transform.GetComponent<Animator>().SetBool("Walk", true);
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y");
            move = new Vector3(mouseX, 0, mouseY).normalized;

            XandY = new Vector2(mouseX, mouseY).normalized;
            Debug.Log(new Vector3(mouseX, mouseY).normalized);
        }
        else
        {
            transform.GetComponent<Animator>().SetBool("Walk", false);
            mouseX = 0;
            mouseY = 0;
        }
    }

    private void FixedUpdate()
    {
        if(isClick == true)
        {
            //// GAME MOVEMENT MECHANIC ///
            StartCoroutine(PlayerMove());
            //// GAME MOVEMENT MECHANIC ///


        }
        else
        {
            move = Vector3.zero;
        }

    }
    IEnumerator PlayerMove()
    {
        

        while (true)
        {
            //Debug.Log(move.normalized);


            rb.MovePosition(transform.position + move * speed * Time.fixedDeltaTime);
          //transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
            if (move != Vector3.zero)

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);

            yield return null;
        }
    }
    public void detectClick()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }
    }

}
