using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _levelBackrgound;

        [Space]
        [Header("Weapons")]
        [SerializeField] private string _machineGunPath;
        [SerializeField] private string _laserGunPath;
        [SerializeField] private string _rocketGunPath;
        [SerializeField] private List<WeaponsData> _weaponsList;
        private PlayerData _player;
        private Level _level;
        private LevelBackground _levelBackground;

        public List<WeaponsData> WeaponsList => _weaponsList;
        
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
        
        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

    }
    
}
   
