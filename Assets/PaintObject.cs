﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintObject : MonoBehaviour
{
    private Rigidbody brushRb;
    private Vector3 mousePos;
    private bool isClick;
    private Vector3 move;
    private float mouseX;
    private float mouseY;
    public Material newMaterialRef;

    // Start is called before the first frame update
    void Start()
    {
        brushRb = transform.gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = new Vector3(0, 0, 0);

            isClick = true;


        }
        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
            move = new Vector3(0, 0, 0);
        }

        
    }

    private void FixedUpdate()
    {
        if (isClick == true)
        {

            //MOUSE INPUT//
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y");
            //MOUSE INPUT

            move = new Vector3(mouseX, mouseY, 0).normalized;
            var pos = transform.position;
            pos.x = Mathf.Clamp(brushRb.position.x, -6, 6);
            pos.y = Mathf.Clamp(brushRb.position.y, 1, 6.5f);
            brushRb.MovePosition(pos + move * Time.fixedDeltaTime * 10f);
        }
        else
        {
            mouseX = 0f;
            mouseY = 0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Paintable"))
        {
            other.gameObject.GetComponent<Renderer>().material = newMaterialRef;
        }
    }
}
