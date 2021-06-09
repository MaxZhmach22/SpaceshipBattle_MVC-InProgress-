using UnityEngine;

namespace HellicopterGame
{
    public class CruisAircraft : Enemy, IExecute, IMove
    {
        private float _speed = 6f;
        public float Speed => _speed;
    
        public void Move(float deltaTime)
        {
            transform.Translate(new Vector3(Mathf.Cos(deltaTime), 1, 0) * deltaTime);
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