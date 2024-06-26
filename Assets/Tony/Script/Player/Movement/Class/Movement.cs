using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class Movement : IMove, IGrounded
    {
        private Rigidbody2D rb;
        private Transform groundCheck;
        private LayerMask groundLayer; 
        public Movement(Rigidbody2D rb, Transform groundCheck , LayerMask groundLayer)
        {
            this.rb = rb;
            this.groundCheck
                = groundCheck;
            this.groundLayer = groundLayer;

        }
        public void Move(float x,float y)
        {
            rb.velocity = new Vector2(x, y);
        }
        public  bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }


    }
}
