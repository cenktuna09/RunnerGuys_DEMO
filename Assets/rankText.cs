using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class rankText : MonoBehaviour
{
    //public TMP_Text Text;
    public GameObject player;
    
    
    public TextMeshProUGUI textRank;
    int playerRank;
    int totalPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        player.GetComponent<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = player.GetComponent<Player_Controller>().currentPos;
        var totalPlayer = player.GetComponent<Player_Controller>().Target.Length;
        textRank.text = playerPos.ToString() + " / " + totalPlayer.ToString(); 
    }
}
