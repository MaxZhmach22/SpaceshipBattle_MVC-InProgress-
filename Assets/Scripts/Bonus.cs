using System;
using System.Security.Cryptography;
using UnityEngine;

namespace HellicopterGame
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private WeaponsData _weaponsDataBonus;

        private void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Projectile"))
            {
                Destroy(gameObject);
            }

            if (other.gameObject.CompareTag("Player"))
            {
                _weaponsDataBonus.BonusTaken("laSer gUn");
                Destroy(gameObject);
            }
        }
        
    }
}