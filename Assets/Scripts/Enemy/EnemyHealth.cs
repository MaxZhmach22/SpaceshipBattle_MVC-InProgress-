using UnityEditorInternal.Profiling.Memory.Experimental;

namespace HellicopterGame
{
    public class EnemyHealth
    {
        public float Max { get; } 
        public float Current { get; private set; }

        public EnemyHealth(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
        
    }
}