using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMath : MonoBehaviour
{
    private float z = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.Cos(Time.time * z) * z, Mathf.Sin(Time.time *z) * z, 0);
        z += 0.001f;
    }
}
