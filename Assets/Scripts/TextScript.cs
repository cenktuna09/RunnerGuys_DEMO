using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextScript : MonoBehaviour
{
    
    public Text text;
    public GameObject[] paintableObjects;
    float percentage;
    private GameObject Brush;
    // Start is called before the first frame update
    void Start()
    {
        paintableObjects = GameObject.FindGameObjectsWithTag("Paintable");
        Brush = GameObject.Find("Brush");

       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(transform.position);
        text.transform.position = namePos;
        percentage = (Mathf.RoundToInt(Brush.GetComponent<PaintObject>().painted));

        if (percentage < 100)
        {
           
            text.text = "Wall Painted: %" + percentage.ToString();
        }
        else
        {
            percentage = 100;
            text.text = "Wall Painted: %100";
        }
        
    }
}
