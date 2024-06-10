using UnityEngine;
using Tony.Pet;

namespace Tony.Projectile
{
    public interface IPetProjectileSpawn

    {
        void Spawn(PetBase pet,int count,Transform target);
    }
}