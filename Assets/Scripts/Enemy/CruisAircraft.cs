using UnityEngine;

namespace HellicopterGame
{
    public class CruisAircraft : Enemy, IExecute
    {
        private float _speed = 6f;
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
            transform.localPosition = transform.parent.position;
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
            ReturnToPool();
        }
    }
}