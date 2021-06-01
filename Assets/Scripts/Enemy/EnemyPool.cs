using System;
using System.Collections;
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
        private EnemyPoolsData _enemyPoolsData;
        private readonly Dictionary<string, Queue<Enemy>> _poolDictionary;
        public EnemyPool(int capacityPool, Transform rootPool, EnemyPoolsData enemyPoolsData)
        {
            _enemyPool = new Dictionary<string, HashSet<Enemy>>();
            _capacityPool = capacityPool;
            _rootPool = rootPool;
            _enemyPoolsData = enemyPoolsData;
            _poolDictionary = new Dictionary<string, Queue<Enemy>>();

            foreach (var pool in _enemyPoolsData.pools)
            {
                Queue<Enemy> objectsPool = new Queue<Enemy>();
                for (int i = 0; i < pool.size; i++)
                {
                    var obj = GameObject.Instantiate(pool.prefab);
                    obj.transform.position = _rootPool.position;
                    obj.transform.SetParent(_rootPool);
                    obj.gameObject.SetActive(false);
                    obj.name += "From youtube";
                    objectsPool.Enqueue(obj);
                }
                _poolDictionary.Add(pool.tag, objectsPool);
            }
        }

        public Enemy SpawnFromPool(string tag)
        {
            if (_poolDictionary[tag].Count != 0)
            {
                Enemy enemy = _poolDictionary[tag].Dequeue();
                _poolDictionary[tag].Enqueue(enemy);
                
                return enemy;
            }

            return null;
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
                var aircraft = Resources.Load<AttackAircraft>("Enemy/Attack Aircraft");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(aircraft);
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

        public Dictionary<string, Queue<Enemy>> GetQueueList()
        {
            return _poolDictionary;
        }
    }
}