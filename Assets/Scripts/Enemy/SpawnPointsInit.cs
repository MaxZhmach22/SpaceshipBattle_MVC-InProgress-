using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class SpawnPointsInit
    {
        private Transform _swapnPoint;
        private Vector3 _point;
        
        public SpawnPointsInit(Vector3 point)
        {
            _point = point;
            _swapnPoint = CreatePoint(_point);
        }
        
        public Transform CreatePoint(Vector3 point)
        {
            var spawnPoint = new GameObject("SpawnPoint (" + point.x.ToString() +";"+ point.y.ToString() +")" );
            spawnPoint.transform.position = point;
            return spawnPoint.transform;
        }

        public Transform GetSpwanPoint()
        {
            return _swapnPoint;
        }
        
    }
}