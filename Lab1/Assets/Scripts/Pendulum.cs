using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Pendulum : MonoBehaviour
{
    private Transform transform;
    private Boolean switchRotate = false;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.x >= 30 && transform.rotation.eulerAngles.x <= 33)
        {
            switchRotate = true;
        }
        else if (transform.rotation.eulerAngles.x > 33 && transform.rotation.eulerAngles.x <= 330)
        {
            switchRotate = false;
        }
        if (switchRotate)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-31, 0, 0), 0.01f);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(31, 0, 0), 0.01f);
        }
    }
}
