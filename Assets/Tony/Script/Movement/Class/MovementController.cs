 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class MovementController : MovementControllerBase
    {
        [SerializeField] private float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật

        [SerializeField] private Rigidbody2D rb;
        private IMove move;
        private IJump jump;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpingPower = 16f;

        public override void Start()
        {
            rb = GetComponentInParent<Rigidbody2D>();
            move = new Movement(this.rb);
            jump = new Jump( this.rb, this.groundCheck, this.groundLayer);
        }


        public override void MoveLeft()
        {
            move.MoveHorizontal(-moveSpeed);
        }


        public override void MoveRight()
        {
            move.MoveHorizontal(moveSpeed);
        }

        public override void Jump()
        {
            jump.Jump(jumpingPower);
        }

        public override void MoveDown()
        {
            move.MoveVertical(-moveSpeed);
        }

        public override void StopMovement()
        {
            rb.velocity = Vector2.zero;
        }

        public override void MoveUp()
        {
            move.MoveVertical(moveSpeed);
        }
    }
}
