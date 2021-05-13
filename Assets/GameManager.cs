using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera mainCam;
    //saveGame saveGameRef;
    public GameObject currentLevel;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        mainCam = Camera.main;
       // var levelRef = Resources.Load("level_" + saveGameRef.levelCountSave) as GameObject;
      //  currentLevel = Instantiate(levelRef);
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // menuRef = GameObject.FindGameObjectWithTag("Menu").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
