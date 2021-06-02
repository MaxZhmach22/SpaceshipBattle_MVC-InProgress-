using System;
using System.Collections.Generic;

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
        private int randomPoolNumber;
        private int playModeInt; //Будет приходить из Data как уровень сложности.

    public EnemyActivator(EnemyPool leftPool, EnemyPool centerPool, EnemyPool rigthPool)
    {
        _leftPool = leftPool;
        _rigthPool = rigthPool;
        _centerPool = centerPool;
        _pools = new List<EnemyPool>();
        _pools.Add(_leftPool);
        _pools.Add(_centerPool);
        _pools.Add(_rigthPool);
        playModeInt = 3;
        randomPoolNumber = new Random().Next(0, 3);

    }

    public void Execute(float deltaTime)
    {
        ActivateShips(deltaTime, _pools[randomPoolNumber]);
    }

    private void ActivateShips(float deltaTime, EnemyPool pool)
    {
        if (timer <= timeCount && playModeInt != 0)
        {
            var enemy = pool.SpawnFromPool("Attack Aircraft");
            enemy.gameObject.SetActive(true);
            timeCount = 0;
            playModeInt -= 1;
        }

        timeCount += deltaTime;
    }
    }
}