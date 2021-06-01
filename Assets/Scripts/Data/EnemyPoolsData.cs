using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "EnemyPoolsData", menuName = "Data/Enemy/EnemyPoolsData")]
    public class EnemyPoolsData : ScriptableObject
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public Enemy prefab;
            public int size;
        }

        public List<Pool> pools;
    }
}