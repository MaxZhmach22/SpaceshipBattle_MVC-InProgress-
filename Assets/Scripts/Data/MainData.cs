using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "MainData", menuName = "MainData/Data")]
    public sealed class MainData : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _levelBackrgound;

        [Space]
        [Header("Weapons")]
        [SerializeField] private List<WeaponsData> _weaponsList;

        [Space] 
        [Header("Enemy")] 
        [SerializeField]
        private string _spawnPointsPath;
        [SerializeField]
        private string _enemyPoolsDataPath;

        [Space] [Header("List of Levels Data")] [SerializeField]
        private List<LevelsData> _levelsList;

        
        private EnemyPoolsData _enemyPoolsData;
        private PlayerData _player;
        private LevelBackground _levelBackground;
        private SpawnPoints _spawnPoints;

        public List<WeaponsData> WeaponsList => _weaponsList;
        public List<LevelsData> LevelsDatas => _levelsList;
        
        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _player;
            }
        }
        
        public LevelBackground LevelBackground
        {
            get
            {
                if (_levelBackground == null)
                {
                    _levelBackground = Load<LevelBackground>("Data/" + _levelBackrgound);
                }

                return _levelBackground;
            }
        }

        public SpawnPoints SpawnPoints
        {
            get
            {
                if (_spawnPoints == null)
                {
                    _spawnPoints = Load<SpawnPoints>("Data/" + _spawnPointsPath);
                }

                return _spawnPoints;
            }
        }

        public EnemyPoolsData EnemyPoolsData
        {
            get
            {
                if (_enemyPoolsData == null)
                {
                    _enemyPoolsData = Load<EnemyPoolsData>("Data/" + _enemyPoolsDataPath);
                }

                return _enemyPoolsData;
            }
        }
        
        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

    }
    
}
   
