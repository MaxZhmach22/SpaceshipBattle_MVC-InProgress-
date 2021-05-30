using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    public sealed class SpawnPointsInit
    {
        private Transform _leftSwapnPoint;
        private Transform _rightSwapnPoint;
        private Transform _centerSwapnPoint;

        private List<Transform> _spawnPoints;

        public SpawnPointsInit(Data _data)
        {
            _leftSwapnPoint = CreatePoint(_data.SpawnPoints.LeftSpawnPoint);
            _rightSwapnPoint = CreatePoint(_data.SpawnPoints.RightSpawnPoint);
            _centerSwapnPoint = CreatePoint(_data.SpawnPoints.CenterpawnPoint);
            _spawnPoints = new List<Transform>();
            _spawnPoints.Add(_leftSwapnPoint);
            _spawnPoints.Add(_rightSwapnPoint);
            _spawnPoints.Add(_centerSwapnPoint);
        }
        
        public Transform CreatePoint(Vector3 point)
        {
            var spawnPoint = new GameObject("SpawnPoint (" + point.x.ToString() +";"+ point.y.ToString() +")" );
            spawnPoint.transform.position = point;
            return spawnPoint.transform;
        }

        public List<Transform> GetSpwanPointList()
        {
            return _spawnPoints;
        }
        
    }
}