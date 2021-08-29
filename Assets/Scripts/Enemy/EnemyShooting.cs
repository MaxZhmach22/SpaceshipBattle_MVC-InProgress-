using UnityEngine;

namespace HellicopterGame
{
    internal sealed class EnemyShooting : IEnemyShooting
    {
        public void Fire(Transform parentTranform, SpriteRenderer parentSprite, GameObject projectilePrefab)
        {
            var projectile = GameObject.Instantiate(projectilePrefab, parentTranform.position /*+ new Vector3(parentSprite.size.x, parentSprite.size.y, 0)*/, Quaternion.identity);
        }
    }
}
