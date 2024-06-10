using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony.Projectile
{
    public class MadScientistProjectile : GenericProjectile
    {
        [System.Obsolete]
        public override void OnTriggerEnter2D(Collider2D collision)
        {
            CharacterStats player = collision.gameObject.GetComponent<CharacterStats>();
            if (player != null)
            {
                player.HitPoint.TakeDamage((int)dam);
                gameObject.SetActive(false);

            }


        }
    }
}
