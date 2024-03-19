using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform rotate;
    void Start()
    {
        rotate = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rotate.Rotate(0,0.5f, 0);
    }
}
