using System;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEditor.SceneTemplate;
using UnityEngine;

namespace HellicopterGame
{
    public class ShootingController : IExecute
    {
        private MainData _data;
        private Transform _playerPosition;
        private List<IWeapon> _weaponsList;
        private int _currentWeapon = 0;
        private ViewServices _viewServices;
        private GameObject bullet;
        
        public ShootingController(Transform getPlayer, MainData data, WeaponsListInit weaponsList, ViewServices viewServices)
        {
            _data = data;
            _playerPosition = getPlayer;
            _weaponsList = weaponsList.GetWeaponsList();
            _viewServices = viewServices;
            foreach (var weapon in _weaponsList)
            {
                weapon.OnBonusTaken += ChangeWeapon;
            }
        }

        public void ChangeWeapon(string weaponName)
        {
            var str = weaponName.ToLower();
            switch (str)
            {
                case "machine gun":
                    _currentWeapon = 0;
                    break;
                case "laser gun":
                    _currentWeapon = 1;
                   break;
                case "rocket gun":
                    _currentWeapon = 2;
                    break;
                default:
                    _currentWeapon = 0;
                    break;
            }
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        
        private void Shoot()
        {
            
            bullet = _viewServices.Create(_weaponsList[_currentWeapon].Prefab);
            bullet.transform.position = _playerPosition.position + _data.Player.StartShootingPoint; 
            bullet.transform.rotation = new Quaternion(0,0,180,0);
            var rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(Vector2.up * _weaponsList[_currentWeapon].FireSpeed, ForceMode2D.Impulse);
            
        }
        
    }
}