using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony.Player
{
    public abstract class PlayerControllerBase : MonoBehaviour
    {
        [SerializeField] protected CharacterStats stats;
        [SerializeField] protected HeroAnimationControllerBase heroAnimCtrl;
        [SerializeField] protected MovementController movementController;
        private Coroutine damageCoroutine;
        private float lastDamageTime;
        public CharacterStats Stats { get => stats; }
        public MovementController MovementController { get => movementController; }

        public virtual void TakeDam(float dam)
        {
            Stats.HitPoint.TakeDamage((int)dam);
            heroAnimCtrl.TakeDamage();
            lastDamageTime = Time.time;

            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(ResetTakeDamageAnimation());
            }
        }

        public virtual IEnumerator ResetTakeDamageAnimation()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.3f);

                if (Time.time - lastDamageTime >= 0.3f)
                {
                    heroAnimCtrl.IdleHeroAnim();
                    damageCoroutine = null;
                    yield break;
                }
            }
        }
        public virtual void MoveLeft()
        {
            MovementController.MoveLeft();
            heroAnimCtrl.RunHeroAnim();
        }
        public virtual void MoveRight()
        {
            MovementController.MoveRight();
            heroAnimCtrl.RunHeroAnim();
        }

        public virtual void Jump()
        {
            MovementController.Jump();
            heroAnimCtrl.JumpHeroAnim();
        }

        public virtual void StopMovement()
        {
            MovementController.StopMovement();
            heroAnimCtrl.IdleHeroAnim();
        }
    }


}
