using System;
using System.Collections.Generic;
using UnityEngine;

namespace HellicopterGame
{
    public class EnemyActivator : IExecute
    {
        private EnemyPool _leftPool;
        private EnemyPool _centerPool;
        private EnemyPool _rigthPool;
        private float timer = 1f;
        private float timeCount = 0f;
        private List<EnemyPool> _pools;
        private int playModeInt; //Будет приходить из Data как уровень сложности.
        private float _timerBetweenDifferentTypesOfShips;
        private float _timerBetweenSameTypeOfShips;
        private List<LevelsData.EnemyInfo> _listOfEnemies;
        private int _countOfSHips;
        private int nextInList = 0;
        
        public EnemyActivator(EnemyPool leftPool, EnemyPool centerPool, EnemyPool rigthPool, Data data)
        {
            _leftPool = leftPool;
            _rigthPool = rigthPool;
            _centerPool = centerPool;

            _listOfEnemies = data.LevelsDatas[0].EnemyInfoList;
            _timerBetweenDifferentTypesOfShips = data.LevelsDatas[0].TimerForDifferentType;
            _timerBetweenSameTypeOfShips = data.LevelsDatas[0].TimerForSameType;
            _countOfSHips = _listOfEnemies[0].count;

            _pools = new List<EnemyPool>();
            _pools.Add(_leftPool);
            _pools.Add(_centerPool);
            _pools.Add(_rigthPool);
        }

        public void Execute(float deltaTime)
        {
           SetActiveShips(deltaTime, _listOfEnemies, _leftPool);
        }
        
        private void SetActiveShips(float deltatime, List<LevelsData.EnemyInfo> listOfEnemies, EnemyPool pool)
        {
            if (_timerBetweenSameTypeOfShips <= timeCount && nextInList<listOfEnemies.Count)
            {
                var enemy = pool.SpawnFromPool(listOfEnemies[nextInList].nameOfEnemy.name);
                enemy.gameObject.SetActive(true);
                _countOfSHips -= 1;
                timeCount = 0;
                if (_countOfSHips == 0)
                {
                    nextInList += 1;
                    if (nextInList < listOfEnemies.Count)
                    {
                        _countOfSHips = listOfEnemies[nextInList].count;
                    }
                }
            }
            timeCount += deltatime;
        }
    }

}