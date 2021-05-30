using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "SpawnPoints", menuName = "Data/Enemy/SpawnPoints")]
    public sealed class SpawnPoints : ScriptableObject
    {
        [SerializeField] private Vector3 _leftSpawnPoint;
        [SerializeField] private Vector3 _rightSpawnPoint;
        [SerializeField] private Vector3 _centerpawnPoint;

        public Vector3 LeftSpawnPoint => _leftSpawnPoint;

        public Vector3 RightSpawnPoint => _rightSpawnPoint;

        public Vector3 CenterpawnPoint => _centerpawnPoint;
    }
}