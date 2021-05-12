using System.IO;
using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _level01;
        private PlayerData _player;
        private Level _level;
        
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
        
        
        
        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
    
}
   
