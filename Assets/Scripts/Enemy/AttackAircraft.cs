using System;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class AttackAircraft : Enemy, IMover, IExecute
    {
        private float _speed = 5f;
        public float Speed => _speed;

        public void Move(float deltaTime)
        {
            transform.Translate(Vector3.up * deltaTime * Speed);
        }

        private void OnBecameInvisible()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        public void Execute(float deltaTime)
        {
            Move(deltaTime);
        }
    }
}