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
        private Transform _rootPool;
        private EnemyPoolsData _enemyPoolsData;
        private readonly Dictionary<string, Queue<Enemy>> _poolDictionary;
        
        public EnemyPool(Transform rootPool, EnemyPoolsData enemyPoolsData)
        {
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
        
        public Dictionary<string, Queue<Enemy>> GetDictionary()
        {
            return _poolDictionary;
        }
    }
}