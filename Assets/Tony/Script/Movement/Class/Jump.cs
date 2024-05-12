using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class Jump : IJump
    {

        private Rigidbody2D rb;
        private bool isFacingRight = true;

        private bool doubleJump;

        private Transform groundCheck;
        private LayerMask groundLayer;
        public Jump( Rigidbody2D rb, Transform groundCheck, LayerMask groundLayer)
        { 
            this.rb = rb;
            this.groundCheck = groundCheck;
            this.groundLayer = groundLayer;
        }
        void IJump.Jump(float force)
        {
            if (IsGrounded())
            {
                doubleJump = false;
            }


            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, force);

                doubleJump = !doubleJump;
            }


            if (rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }


        //private void DoubleJump(float force)
        //{
            

        //    if (IsGrounded())
        //    {
        //        doubleJump = false;
        //    }


        //    if (IsGrounded() || doubleJump)
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, force);

        //        doubleJump = !doubleJump;
        //    }


        //    if (rb.velocity.y > 0f)
        //    {
        //        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //    }

        //    // Flip();
        //}


        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        //private void Flip()
        //{
        //    if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        //    {
        //        Vector3 localScale = transform.localScale;
        //        isFacingRight = !isFacingRight;
        //        localScale.x *= -1f;
        //        transform.localScale = localScale;
        //    }

        //}
    }
}