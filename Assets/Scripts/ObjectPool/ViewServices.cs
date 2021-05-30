using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class ViewServices
    {
        private readonly Dictionary<int, ObjectPool> _viewCache = new Dictionary<int, ObjectPool>(12);
        
        public GameObject Create(GameObject prefab)
        {
            GameObject gameObject;
            if (!_viewCache.TryGetValue(prefab.GetInstanceID(), out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.GetInstanceID()] = viewPool;
            }

           gameObject = viewPool.Pop();
           return gameObject;
        }

        public void Destroy(GameObject prefab)
        {
            _viewCache[prefab.GetInstanceID()].Push(prefab); 
        }
    }
}
