using System;
using UnityEngine;

namespace HellicopterGame
{
    public interface IWeapon
    {
        event Action<float> OnDamageTaken;
        public event Action<string> OnBonusTaken;
        
        public GameObject Prefab{ get; }
        public string Name { get; set; }
        public float Damage { get; set; }
        public float FireSpeed { get; set; }
        public void TakeDamage();
    }
}