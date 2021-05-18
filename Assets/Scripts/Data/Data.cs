using System.IO;
using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _level01;
        [SerializeField] private string _levelBackrgound;
        private PlayerData _player;
        private Level _level;
        private LevelBackground _levelBackground;

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
        
        public Level Level
        {
            get
            {
                if (_level == null)
                {
                    _level = Load<Level>("Data/" + _level01);
                }

                return _level;
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
   
