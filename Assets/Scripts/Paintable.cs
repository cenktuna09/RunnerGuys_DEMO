using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public GameObject brush;
    public float brushSize = 0.1f;
    private Collider m_Collider;
    private Vector3 m_Size;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();

        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;

        //Output to the console the size of the Collider volume
        Debug.Log("Collider Size : " + m_Size);

       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float MouseX = Input.GetAxis("Mouse X");
            float MouseY = Input.GetAxis("Mouse Y");
            var center = transform.gameObject.GetComponent<BoxCollider>().center;
            var go = Instantiate(brush, new Vector3(center.x + MouseX,center.y + MouseY,transform.position.z), Quaternion.identity, transform);
            /*
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray,out hit))
            {
                var go = Instantiate(brush,new Vector3(m_Size.x,m_Size.y,transform.position.z), Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * brushSize;
            }
            */

            

        }
    }
}
