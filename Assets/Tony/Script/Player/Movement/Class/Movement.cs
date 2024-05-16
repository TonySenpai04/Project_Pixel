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
        public void Move(float x,float y)
        {
            rb.velocity = new Vector2(x, y);
        }

       
    }
}
