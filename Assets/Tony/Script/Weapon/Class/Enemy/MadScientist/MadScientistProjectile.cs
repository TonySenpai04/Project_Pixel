using System.Collections;
using System.Collections.Generic;
using Tony.Player;
using UnityEngine;
namespace Tony.Projectile
{
    public class MadScientistProjectile : GenericProjectile
    {
        [System.Obsolete]
        public override void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerControllerBase player = collision.gameObject.GetComponent<PlayerControllerBase>();
            if (player != null)
            {
                player.TakeDam((int)dam);
                gameObject.SetActive(false);

            }


        }
    }
}
