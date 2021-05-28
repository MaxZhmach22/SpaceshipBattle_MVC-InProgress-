using System;
using UnityEngine;

namespace HellicopterGame
{
    public class ExampleWeaponChange : MonoBehaviour
    {
        [SerializeField] private ExampleChangeWeaponData _data;
        public Action<int> OnWeaponUp;
        public string weaponName;
        private Rigidbody2D _rigidbody;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _data = Resources.Load<ExampleChangeWeaponData>("Data/ExampleChangeWeaponData");
        }

        private void OnTriggerEnter2D(Collider2D other)
        { 
            Debug.Log(other.name);
            _data.OnWeaponBonusUp?.Invoke(_data.Weapon);
        }

    }
}