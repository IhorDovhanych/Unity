using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody sphere;
    public int radius;
    private float startTime;
    private float startX;
    void Start()
    {
        sphere = GetComponent<Rigidbody>();
        startTime = Time.time;
        startX = sphere.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        float x = startX + radius * (t-Mathf.Sin(t));
        
        sphere.position = new Vector3(x, sphere.position.y, sphere.position.z);
    }
}
