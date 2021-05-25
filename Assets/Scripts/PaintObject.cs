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
    private GameObject Canvas;
    private float wallCount;
    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.FindGameObjectWithTag("Wall");
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        painted = 0;
        brushRb = transform.gameObject.GetComponent<Rigidbody>();
        wallCount = wall.transform.GetChild(0).GetComponent<TextScript>().paintableObjects.Length;
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

        if(isPainted)
        {

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
            pos.x = Mathf.Clamp(brushRb.position.x, -6, 6.6f);
            pos.y = Mathf.Clamp(brushRb.position.y, 1, 6.5f);
            brushRb.MovePosition(pos + move * 15 * Time.fixedDeltaTime);
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
            
            other.gameObject.GetComponent<Renderer>().material = newMaterialRef;
            other.gameObject.GetComponent<Collider>().enabled = false;
            painted += 1 / wallCount * 100;
        }
    }
}
