using System.Collections;
using System.Collections.Generic;
using HellicopterGame;
using UnityEngine;

public class BomberAircraft : Enemy, IExecute, IMove
{
    private IEnemyShooting _shoot;
    public EnemyData bomberData;
    private float timerForShoot;
    private Transform _player;

    private SpriteRenderer spriteRenderer = new SpriteRenderer();

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 4;
        Speed = 5;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _shoot = new EnemyShooting();
        timerForShoot = bomberData.TimerForShoot;
        
    }

    public override void Move(float deltaTime)
    {

        if (transform.position.y < 0 + bomberData.Offset)
        {
            float xValue = Mathf.Cos(Time.time);
            transform.Translate((new Vector3(xValue + bomberData.Amplitude, -1, 0)) * deltaTime * Speed, Space.World);
        }
        else transform.Translate(Vector3.down * deltaTime * bomberData.Speed, Space.World);
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
            if (Vector3.Distance(transform.position, _player.transform.position) < bomberData.DistanceOpenFire)
            {
                Shoot(deltaTime);
            }
        }
        
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Player"))
        {
            ReturnToPool();
        }
    }

    public override void Shoot(float deltaTime)
    {
       
       if(timerForShoot > 1)
        {
            _shoot.Fire(transform, spriteRenderer, bomberData.EnemyProjectile);
            timerForShoot = 0;
        }
        timerForShoot += deltaTime;
    }
}
