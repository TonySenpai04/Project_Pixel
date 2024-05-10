using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class Movement : IMove
    {
        private Rigidbody2D rb;
        public Movement(Rigidbody2D rb)
        {
            this.rb = rb;

        }
        public void MoveHorizontal(float dir)
        {
            rb.velocity = new Vector2(dir, rb.velocity.y);
        }

        public void MoveVertical(float dir)
        {
            rb.velocity = new Vector2(rb.velocity.x, dir);
        }
    }
}
