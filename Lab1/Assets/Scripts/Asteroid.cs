using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody rb;
    public int radius;
    private float startTime;
    private float startX, startY;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startX = rb.position.x;
        startY = rb.position.y;
    }

    void Update()
    {
        float t = Time.time;
        float x = startX + radius * Mathf.Pow(Mathf.Cos(t), 3);
        float y = startY + radius * Mathf.Pow(Mathf.Sin(t), 3);
        rb.position = new Vector3(x, y, rb.position.z);
    }
}
