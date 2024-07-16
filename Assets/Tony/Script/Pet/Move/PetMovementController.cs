
using UnityEngine;
namespace Tony.Pet
{

    public abstract class PetMovementController : MonoBehaviour
    {
        [SerializeField] protected Transform player;
        [SerializeField] protected float flyHeight = 2.0f;
        [SerializeField] protected float offsetX = 1.3f;
        [SerializeField] protected float moveSpeed = 3.0f;
        [SerializeField] protected bool isFlying = false;
        [SerializeField] protected bool isFacingRight = true;
        protected IMove petMove;
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
            SyncPetRotationWithPlayer();
            //if ((isFacingRight && player.localScale.x < 0) || (!isFacingRight && player.localScale.x > 0))
            //{
            //    Flip();
            //}
        }
        public virtual void SyncPetRotationWithPlayer()
        {
            Vector3 scale = transform.localScale;
            scale.x = player.localScale.x > 0 ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        public virtual void Fly()
        {
            
           petMove.Move(offsetX, flyHeight);
            
        }

        public virtual void MoveOnGround()
        {
            
            petMove.Move(offsetX, 0);
            
        }
       
 
    }
}
