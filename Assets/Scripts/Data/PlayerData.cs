using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Unit/Player")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        public Sprite Sprite;
        [SerializeField] private GameObject _playerModel;
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField] private Vector3 _position;
        [SerializeField] private int _playerHealth;
        public float Speed => _speed;

        public int Hp
        {
            get
            {
                return _playerHealth;
            }
            set
            {
                _playerHealth = value;
            }
        }
        public Vector3 Position => _position;
        
        


        public void CreatePlayer()
        {
            Instantiate(_playerModel, _position, Quaternion.identity);
        }
    }
}