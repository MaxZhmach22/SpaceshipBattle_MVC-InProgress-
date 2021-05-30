using System;
using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }

}
