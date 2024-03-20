using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody sphere;
    public int radius;
    private float startX, startY;
    void Start()
    {
        sphere = GetComponent<Rigidbody>();
        startX = sphere.position.x;
        startY = sphere.position.y;
    }

    void Update()
    {
        float t = Time.time;
        float x = startX + radius * (t - Mathf.Sin(t));
        float y = startY + radius * (1 - Mathf.Cos(t));
        sphere.position = new Vector3(x, y, sphere.position.z);
    }
}
