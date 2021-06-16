using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemyProjectile : MonoBehaviour
{
    private GameObject _player;
    public float Speed = 10;
    private Vector3 _playerPosition;
    private Vector3 _startProjectilePosition;
    private Vector3 _endProjectilePosition;
   

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPosition = _player.transform.position;
        _startProjectilePosition = transform.position;
        _endProjectilePosition = _playerPosition + (_playerPosition - _startProjectilePosition);
    }

    private void Update()
    {
            transform.position = Vector3.MoveTowards(transform.position, _endProjectilePosition, Speed * Time.deltaTime);
        if (Mathf.Approximately(transform.position.x + transform.position.y, _endProjectilePosition.x + _endProjectilePosition.y))
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);        
    }
    

}
