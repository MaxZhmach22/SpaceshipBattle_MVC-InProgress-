using UnityEngine;

namespace HellicopterGame
{
    public class PlayerInitialization: IInitialization

    {
    private IPlayerFactory _playerFactory;
    private Transform _player;
    private PlayerData _playerData;

    public PlayerInitialization(IPlayerFactory playerFactory, PlayerData playerData)
    {
        _playerFactory = playerFactory;
        _player = _playerFactory.CreatePlayer();
        _playerData = playerData;
        _player.position = _playerData.Position;
    }

    public void Initialization()
    {
        
    }
    
    public Transform GetPlayer()
    {
        return _player;
    }
    
    }
}