using UnityEngine;

namespace HellicopterGame
{
    public class LevelInitialization
    {
        private Data _data;
        private Transform _gameObject;
        public LevelInitialization(Data data)
        {
            _data = data;
            var gameObject = _data.Level.CreateGameObject();
            _gameObject = gameObject.transform;
        }
        
        public Transform GetPlayer()
        {
            return _gameObject;
        }
        
    }
}