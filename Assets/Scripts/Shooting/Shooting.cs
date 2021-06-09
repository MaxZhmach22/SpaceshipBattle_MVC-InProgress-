using System;
using UnityEngine;

namespace HellicopterGame
{
    public class Shooting : MonoBehaviour
    {
        public Transform[] firePoints;
        public GameObject bulltePrefab;

        public float bullteForce = 20f;


        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        void Shoot()
        {
            foreach (var firePoint in firePoints)
            {
                GameObject bullet = Instantiate(bulltePrefab, firePoint.position, new Quaternion(0f,0f,180f, 0f));
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bullteForce, ForceMode2D.Impulse);
                Destroy(bullet, 3f);
            }
        }
    }
}