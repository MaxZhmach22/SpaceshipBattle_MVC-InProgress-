using UnityEngine;

namespace HellicopterGame
{
    public class CruisAircraft : Enemy, IExecute, IMove
    {

        private SpriteRenderer spriteRenderer = new SpriteRenderer();

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = 4;
            Speed = 5;
        }


        public override void Move(float deltaTime)
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

        public override void Shoot(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}