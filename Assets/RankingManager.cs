using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class RankingManager : MonoBehaviour
{
    public Vector3 relativePosition = new Vector3();
    public Transform Player;  //Player Car 
    public Transform[] Target;  // AI cars

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int numberOfFrontCars = 0;
        for (int i = 0; i < 7; i++)
        {

            Vector3 relativePosition = transform.InverseTransformPoint(Target[i].transform.position);
            // calculate relative pos of  player car and AI cars . where Target is AI cars. Drag and drop your AI cars in Target Transform.
            if (relativePosition.z < 0)
            {

                Debug.Log("Front of AI ");
                numberOfFrontCars++;
            }
            Debug.Log("Current Rank ::  " + (8 - numberOfFrontCars));
        }

    }
}
