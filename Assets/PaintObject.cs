using UnityEngine;

public class PaintObject : MonoBehaviour
{
    private bool mainPlayerFinish;
    private Rigidbody brushRb;
    private Vector3 mousePos;
    private bool isClick;
    private Vector3 move;
    private float mouseX;
    private float mouseY;
    public Material newMaterialRef;
    public float painted = 0;
    private GameObject wall;
    private bool isPainted;

    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.Find("Wall");
        //mainPlayerFinish = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player_Controller>().isFinished;
        painted = 0;
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
            isPainted = true;
            float objLength = wall.transform.GetChild(0).GetComponent<TextScript>().paintableObjects.Length;
            other.gameObject.GetComponent<Renderer>().material = newMaterialRef;
            other.gameObject.GetComponent<Collider>().enabled = false;
            painted += 1 / objLength * 100;

                Debug.Log(painted);
                Debug.Log(objLength);
        }
    }
}
