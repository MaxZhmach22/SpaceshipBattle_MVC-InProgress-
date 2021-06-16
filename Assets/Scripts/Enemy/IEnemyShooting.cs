using UnityEngine;

internal interface IEnemyShooting
{
    void Fire(Transform parentTranform, SpriteRenderer parentSprite, GameObject projectilePrefab);

}