using UnityEngine;

namespace Tony
{
    public interface IPetProjectileSpawn

    {
        void Spawn(Pet pet,int count,Transform target);
    }
}