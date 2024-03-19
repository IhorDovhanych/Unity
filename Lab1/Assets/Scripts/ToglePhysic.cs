using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToglePhysic : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump")){
            rb.useGravity = true;
        }
    }
}
