using UnityEngine;

namespace Tony
{
    public interface IEnemyProjectileSpawn
    {
        void Spawn(Enemy enemy, int count, Transform target);
    }
}