using System;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class AttackAircraft : Enemy, IExecute, IMove
    {
        private float _speed = 5f;
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
}