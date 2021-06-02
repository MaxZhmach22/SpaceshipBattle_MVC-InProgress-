using System;
using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    [CreateAssetMenu(fileName = "Level", menuName = "Data/Level/LevelLogic")]
    public sealed class LevelsData : ScriptableObject
    {
        [Serializable]
        public struct EnemyInfo
        {
            public GameObject nameOfEnemy;
            public int count;
        }

        [SerializeField] private List<EnemyInfo> _enemyInfoList;
        
        [Header("Time between spawn of different types of ships")]
        [SerializeField] private float _timerForDifferentType;
        
        [Header("Time between spawn of same types of ships")]
        [SerializeField] private float _timerForSameType;


        public float TimerForDifferentType => _timerForDifferentType;

        public float TimerForSameType => _timerForSameType;

        public List<EnemyInfo> EnemyInfoList => _enemyInfoList;
    }
}