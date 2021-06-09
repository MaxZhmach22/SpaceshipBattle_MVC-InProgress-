using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Unit/Player")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        [SerializeField] private string _playersName;
        [SerializeField] private Sprite _playerSprite;
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField] private Vector3 _position;
        [SerializeField] private int _playerHealth;
        [SerializeField] private Vector3 _startShootingPoint;

        public string PlayersName
        {
            get => _playersName;
            set => _playersName = value;
        }

        public float Speed => _speed;

        public Vector3 StartShootingPoint => _startShootingPoint;

        public Sprite PlayerSprite => _playerSprite;

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
        
    }
}