using UnityEngine;

namespace HellicopterGame
{
    public abstract class Enemy : MonoBehaviour
    {
        public EnemyHealth Health { get; private set; }
 
    }
}