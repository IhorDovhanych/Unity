using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    public GameObject MovedBlock;
    public float speed;
    private Boolean changeDirection = true;
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if((MovedBlock.transform.position != pointB.transform.position && changeDirection)
            || (MovedBlock.transform.position == pointA.transform.position && !changeDirection)
            )
        {
            MovedBlock.transform.position = Vector3.MoveTowards(MovedBlock.transform.position, pointB.transform.position, speed);
            changeDirection = true;
        }
        else
        {
            MovedBlock.transform.position = Vector3.MoveTowards(MovedBlock.transform.position, pointA.transform.position, speed);
            changeDirection = false;
        }
    }
}
