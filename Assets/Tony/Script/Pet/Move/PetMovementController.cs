
using UnityEngine;
namespace Tony.Pet
{

    public class PetMovementController : MonoBehaviour
    {
        public Transform player;
        public float flyHeight = 2.0f;
        public float flyOffsetX = 2.0f;
        public float moveSpeed = 3.0f;
        public bool isFlying = false;
        private bool isFacingRight = true;
        private IMove petMove;
        private void Start()
        {
            petMove = new PetMove(this.gameObject, this.player, this.moveSpeed);
        }

        void Update()
        {
            if (isFlying)
            {
                Fly();
            }
            else
            {
                MoveOnGround();
            }

            if ((isFacingRight && player.localScale.x < 0) || (!isFacingRight && player.localScale.x > 0))
            {
                Flip();
            }
        }

        void Fly()
        {
            if (isFacingRight)
            {
                petMove.Move(flyOffsetX, flyHeight);

            }
            else
            {
                petMove.Move(-flyOffsetX, flyHeight);

            }

        }

        void MoveOnGround()
        {
            if (isFacingRight)
            {
                petMove.Move(flyOffsetX, 0);
            }
            else
            {
                petMove.Move(-flyOffsetX, 0);
            }
        }

        void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1; // Lật đối tượng pet
            transform.localScale = scale;
        }
    }
}
