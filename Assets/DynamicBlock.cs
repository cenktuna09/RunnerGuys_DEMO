using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBlock : MonoBehaviour
{
    private Rigidbody blockRb;
    private Vector3 targetPos;
    private Vector3 firstPos;

    [SerializeField] Transform[] positions;
    [SerializeField] float objectSpeed;
    int nextPosIndex;
    Transform nextPos;
    private Vector3 movePos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = positions[0];
        blockRb = transform.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    void MoveObject()
    {
        if(blockRb.position.x == nextPos.position.x)
        {
            nextPosIndex++;
            if (nextPosIndex >= positions.Length)
            {
                nextPosIndex = 0;
            }
            nextPos = positions[nextPosIndex];
        }
        else
        {
             movePos = Vector3.MoveTowards(transform.position, nextPos.position, objectSpeed * Time.deltaTime);
            blockRb.MovePosition(movePos);
        }
    }
}


