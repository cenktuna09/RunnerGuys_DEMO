using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_manager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject[] tilePrefabsSon;
    private Transform playerTransform;
    private float spawnZ = 0f;
    private float tileLength = 59.88f;
    private int amnTilesOnScreen = 4;
    private float safeZone = 72.0f;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;
    private bool onetime = false;
    private bool sonMap = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
