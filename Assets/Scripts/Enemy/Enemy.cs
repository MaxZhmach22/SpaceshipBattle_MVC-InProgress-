using UnityEngine;

namespace HellicopterGame
{
    public abstract class Enemy : MonoBehaviour
    {
        private float _speed;
        public float Speed { get => _speed; protected set => _speed = value; }

        public EnemyHealth Health { get; protected set; }

        public abstract void Move(float deltaTime);
       
    }
}