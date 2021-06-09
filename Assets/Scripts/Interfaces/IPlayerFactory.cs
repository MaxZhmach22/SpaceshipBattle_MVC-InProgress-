using UnityEngine;

namespace HellicopterGame
{
    public interface IPlayerFactory
    {
        public Transform CreatePlayer();
    }
}