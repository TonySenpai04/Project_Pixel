using UnityEngine;
using Tony.Enemy;
namespace Tony.Projectile
{
    public interface IEnemyProjectileSpawn
    {
        void Spawn(EnemyBase enemy, int count, Transform target);
    }
}