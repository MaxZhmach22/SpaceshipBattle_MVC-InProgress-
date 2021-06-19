using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemyProjectile : MonoBehaviour
{
    public event Action onCollisionEnterPlayer;
    private GameObject _player;
    public float Speed = 10;
    private Vector3 _playerPosition;
    private Vector3 _startProjectilePosition;
    private Vector3 _endProjectilePosition;
    private EventCatch _eventCatch;
   

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPosition = _player.transform.position;
        _startProjectilePosition = transform.position;
        _endProjectilePosition = _playerPosition + (_playerPosition - _startProjectilePosition);
        _eventCatch = FindObjectOfType<EventCatch>();
        onCollisionEnterPlayer += _eventCatch.EventCatchMethod;
    }

    private void Update()
    {
            transform.position = Vector3.MoveTowards(transform.position, _endProjectilePosition, Speed * Time.deltaTime);
        if (Mathf.Approximately(transform.position.x + transform.position.y, _endProjectilePosition.x + _endProjectilePosition.y))
            Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onCollisionEnterPlayer?.Invoke();
            onCollisionEnterPlayer -= _eventCatch.EventCatchMethod;
        }
        Debug.Log(collision.gameObject.name);
    }

}
