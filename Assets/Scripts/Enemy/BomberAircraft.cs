using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEngine;

public class BomberAircraft : Enemy, IExecute
{
    private float _speed = 2f;
    public float Speed => _speed;
    
    public void Move(float deltaTime)
    {
        transform.Translate(Vector3.up * deltaTime * Speed);
    }

    private void OnBecameInvisible()
    {
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        transform.position = transform.parent.position;
        transform.gameObject.SetActive(false);
    }

    public void Execute(float deltaTime)
    {
        if (isActiveAndEnabled)
        {
            Move(deltaTime);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Player"))
        {
            ReturnToPool();
        }
    }
    
}
