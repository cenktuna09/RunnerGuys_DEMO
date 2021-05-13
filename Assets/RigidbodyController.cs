using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    public float Speed = 15f;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public LayerMask Ground;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded;
    private Transform _groundChecker;

    private bool isClick;
    private Touch touch;
    private float speedModifier = 0.025f;

    void Start()
    {
        _isGrounded = false;
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // CLICK CHECK //
        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
        }
        // CLICK CHECK //

        // KEYBOARD INPUT //
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;
    }
    // KEYBOARD INPUT //

    void FixedUpdate()
    {
        // FORWARD GO GO GO // BU KISIMA BIRAZ DAHA GELISTIRILMIS BIR HIZ - HIZLANMA YAZILMALI
        _body.velocity = (new Vector3(_body.velocity.x, _body.velocity.y, 20f));
        // FORWARD GO GO GO //

        // MOBILE TOUCH INPUT //
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {

                _body.MovePosition(new Vector3(
                     _body.position.x + touch.deltaPosition.x * speedModifier,
                     _body.position.y,
                    _body.position.z));
            }
        }
        // MOBILE TOUCH INPUT //


        // CLICK FUNCTION //
        if (isClick == true)
        {
            // _body.velocity = (new Vector3(_body.velocity.x, _body.velocity.y, _body.velocity.z + 10f));
            //_body.AddForce(0, 0, 100f, ForceMode.VelocityChange);
            //Debug.Log(isClick);
        }
        else
        {

        }
        // CLICK FUNCTION //

        // KEYBOARD FUNCTION //
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
        // KEYBOARD FUNCTION //

        // HAVADAYSA EKSTRA DUSME KUVVETI//
        if (_isGrounded != true)
        {

            _body.AddForce(0, -25f, 0, ForceMode.Acceleration);
            //_isGrounded = true;
        }
        // HAVADAYSA EKSTRA DUSME KUVVETI//
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ramp"))
        {
            _body.AddForce(0, 75f, 75f, ForceMode.Force);
            _isGrounded = false;
            Debug.Log("RAMPACIKILDI");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ramp") || collision.gameObject.CompareTag("Floor"))
        {
            _isGrounded = true;
            Debug.Log("isgroundedTure");

            if (collision.gameObject.CompareTag("Bump"))
            {
                _body.AddForce(-70f, 0, 0, ForceMode.Force);
            }
        }
    }
}
