using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "EnemyPoolsData", menuName = "Data/Enemy/EnemyPoolsData")]
    
    public class EnemyPoolsData : ScriptableObject 
    {
        /// <summary>
        /// Это Scriptable object со списком пулов для врагов.
        /// </summary>
        
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