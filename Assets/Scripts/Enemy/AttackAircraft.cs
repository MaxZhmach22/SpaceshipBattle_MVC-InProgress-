using System;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class AttackAircraft : Enemy, IExecute, IMove
    {
        private SpriteRenderer spriteRenderer = new SpriteRenderer();


        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = 4;
            Speed = 7;

            
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
            if (other.tag.Contains("Projectile"))
            {
                
            }
            
        }

        public override void Move(float deltaTime)
        {
            transform.Translate(Vector3.up * deltaTime * Speed);
        }
    }
}