using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEngine;

public class BomberAircraft : Enemy, IExecute, IMove
{

    private float _amplitude = 1;
    private float _offset = 5;

    private SpriteRenderer spriteRenderer = new SpriteRenderer();

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 4;
        Speed = 5;
    }

    public override void Move(float deltaTime)
    {

        if (transform.position.y < 0 + _offset)
        {
            float xValue = Mathf.Cos(Time.time);
            transform.Translate((new Vector3(xValue + _amplitude, -1, 0)) * deltaTime * Speed, Space.World);
        }
        else transform.Translate(Vector3.down * deltaTime * Speed, Space.World);
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
