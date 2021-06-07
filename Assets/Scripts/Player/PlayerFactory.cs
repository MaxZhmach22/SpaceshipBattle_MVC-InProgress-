using UnityEngine;

namespace HellicopterGame
{
    public class PlayerFactory: IPlayerFactory
    {
        private GameObject _player;
        private PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }
        
        public Transform CreatePlayer()
        {
            
            
            _player = new GameObject(_playerData.PlayersName);
            _player.tag = "Player";
            _player.AddComponent<SpriteRenderer>();
            _player.AddComponent<BoxCollider2D>();
            _player.AddComponent<Rigidbody2D>();
            Rigidbody2D rigidbody2D = _player.GetComponent<Rigidbody2D>();
            rigidbody2D.gravityScale = 0;
            var boxColllider = _player.GetComponent<BoxCollider2D>();
            boxColllider.size = new Vector2(2, 2);
            SpriteRenderer renderer = _player.GetComponent<SpriteRenderer>();
            renderer.sprite = _playerData.PlayerSprite;
            _player.transform.rotation = new Quaternion(0, 0, 180, 0);
            renderer.sortingOrder = 4;
            var shootingPoint = new GameObject("Shooting point");
            shootingPoint.transform.position = _playerData.StartShootingPoint;
            shootingPoint.transform.SetParent(_player.transform);
            
            return _player.transform;
        }
    }
}