using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HellicopterGame
{
    public class EnemyPool
    {
        private readonly Dictionary<string, HashSet<Enemy>> _enemyPool;
        private readonly int _capacityPool;
        private Transform _rootPool;
        
        public EnemyPool(int capacityPool, Transform rootPool)
        {
            _enemyPool = new Dictionary<string, HashSet<Enemy>>();
            _capacityPool = capacityPool;
            _rootPool = rootPool;
        }
        public Enemy GetEnemy(string type)
        {
            Enemy result;
            switch (type)
            {
                case "Attack Aircraft":
                    result = GetEnemy(GetListEnemies(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }
            return result;
        }

        private HashSet<Enemy> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy>();
        }

        private Enemy GetEnemy(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null )
            {
                var laser = Resources.Load<AttackAircraft>("Enemy/Attack Aircraft");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }
                enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
                GetEnemy(enemies);
            }
            return enemy;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.position = _rootPool.position;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}