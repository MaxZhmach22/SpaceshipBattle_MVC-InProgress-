namespace HellicopterGame
{
    public class EnemyActivator : IExecute
    {
        private EnemyPool _leftPool;
        private EnemyPool _centerPool;
        private EnemyPool _rigthPool;
        private float timer = 1f;
        private float timeCount = 0f;

    public EnemyActivator(EnemyPool leftPool, EnemyPool centerPool, EnemyPool rigthPool)
    {
        _leftPool = leftPool;
        _rigthPool = rigthPool;
        _centerPool = centerPool;
    }

    public void Execute(float deltaTime)
    {
        if (timer <= timeCount)
        {
            var enemy = _leftPool.SpawnFromPool( "Attack Aircraft");
            enemy.gameObject.SetActive(true);
            timeCount = 0;
        }

        timeCount += deltaTime;
    }
    }
}