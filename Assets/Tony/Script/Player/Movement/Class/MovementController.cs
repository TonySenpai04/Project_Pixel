using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class MovementController : MovementControllerBase
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Transform player;
        [SerializeField] private Rigidbody2D rb;
        private IMove move;
        private IJump jump;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpingPower = 16f;
        private bool facingRight = true;


        public override void Start()
        {
            rb = GetComponentInParent<Rigidbody2D>();
            heroAnimationController = GetComponentInParent<HeroAnimationControllerBase>();
            move = new Movement(this.rb, this.groundCheck, this.groundLayer);
            jump = new Jump(this.rb, this.groundCheck, this.groundLayer);
            player = rb.transform;
        }

        //public override void Update()
        //{
        //    Debug.Log(this.groundCheck.position.y);
        //}
        public override void MoveLeft()
        {
            if (CharacterStats.instance.HitPoint.GetCurrentHealth() > 0)
            {
                heroAnimationController.RunHeroAnim();
                move.Move(-moveSpeed, rb.velocity.y);
                if (facingRight)
                {
                    Flip();
                }
            }
        }


        public override void MoveRight()
        {
            if (CharacterStats.instance.HitPoint.GetCurrentHealth() > 0)
            {
                heroAnimationController.RunHeroAnim();
                move.Move(moveSpeed, rb.velocity.y);
                if (!facingRight)
                {
                    Flip();
                }
            }
        }

        public override void Jump()
        {
            if (CharacterStats.instance.HitPoint.GetCurrentHealth() > 0)
            {
                heroAnimationController.JumpHeroAnim();
                jump.Jump(jumpingPower);
            }
        }

        public override void MoveDown()
        {
            if (CharacterStats.instance.HitPoint.GetCurrentHealth() > 0)
            {
                move.Move(rb.velocity.x, -moveSpeed);
            }
        }

        public override void StopMovement()
        {

            rb.velocity = Vector2.zero;

            heroAnimationController.IdleHeroAnim();

        }

        public override void MoveUp()
        {
            if (CharacterStats.instance.HitPoint.GetCurrentHealth() > 0)
            {
                if (((IGrounded)move).IsGrounded())
                {
                    move.Move(rb.velocity.x, moveSpeed);

                }
            }
        }
        private void Flip()
        {
            Vector3 scale = player.transform.localScale;
            scale.x *= -1;
            player.transform.localScale = scale;
            facingRight = !facingRight;
        }
    }
}
