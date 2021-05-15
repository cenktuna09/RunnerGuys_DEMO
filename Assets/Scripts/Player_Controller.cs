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

    private bool rotateObs;
    private float maxRotateSpeed;
    private bool rotateObsLeft;
    private bool rotateObsRight;
    private bool stickHit;
    // Start is called before the first frame update
    void Start()
    {
        speed = 7.5f;
        maxRotateSpeed = 5f;
        Application.targetFrameRate = 120;
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
            //ANIM
            transform.GetComponent<Animator>().SetBool("Walk", true);
            //ANIM

            //MOUSE INPUT//
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y");
            //MOUSE INPUT

            move = new Vector3(mouseX, 0, mouseY).normalized;

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

        if(rotateObsLeft == true)
        {

            rb.AddForce(-10f, 0, 0);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxRotateSpeed);
           
        }
        else
        {

        }
        if(rotateObsRight == true)
        {
            rb.AddForce(10f, 0, 0);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxRotateSpeed);
        }
        else
        {

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("RotateObsLeft"))
        {
            rotateObsLeft = true;
        }

        if (collision.gameObject.CompareTag("RotateObsRight"))
        {
            rotateObsRight = true;
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotateObsLeft"))
        {
            rotateObsLeft = false;
        }
        if (collision.gameObject.CompareTag("RotateObsRight"))
        {
            rotateObsRight = false;
        }
    }
    IEnumerator PlayerMove()
    {
        

        while (true)
        {
            rb.MovePosition(transform.position + move * speed * Time.fixedDeltaTime);
          
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
