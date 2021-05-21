using UnityEngine;

public class PaintScript : MonoBehaviour
{
    public GameObject brush;
    private Vector2 mousePos;
    private bool isClick;
    private float mouseX;
    private float mouseY;
    private Vector3 move;
    Vector2 pointPos;
    LineRenderer currentLineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = transform.parent.gameObject.GetComponent<BoxCollider>().center;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        if(Input.GetMouseButton(0))
        {
            
            AddAPoint();
        }

        if(Input.GetMouseButtonDown(0))
        {
            mousePos += new Vector2(mouseX, mouseY);
            isClick = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
        }

        if (isClick == true)
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y");

            CreateBrush();

         //   Instantiate(brush, move,Quaternion.identity);
        }
    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        Vector2 mousePos = transform.parent.gameObject.GetComponent<BoxCollider>().center;

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void AddAPoint()
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}
