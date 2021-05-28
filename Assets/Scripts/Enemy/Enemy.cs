using UnityEngine;

namespace HellicopterGame
{
    public abstract class Enemy : MonoBehaviour, IInitialization
    {
        public Health Health { get; private set; }

        public static AttackAircraft CreateAttackAircraft(Health hp)
        {
            var enemy = Instantiate(Resources.Load<AttackAircraft>("Enemy/Attack Aircraft"));
            enemy.Health = hp;
            return enemy;
        }

        public void Initialization()
        {
           
        }
    }
}