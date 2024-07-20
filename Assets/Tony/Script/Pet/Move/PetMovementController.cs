
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
        private float standingThreshold =1.4f;

        protected IMove petMove;
        public virtual void Start()
        {

            petMove = new PetMove(this.gameObject, this.player, this.moveSpeed);
        }

        public virtual void Update()
        {


        }
        public virtual bool IsStandingStill()
        {
            Vector3 currentPosition = transform.position;
            bool isStandingStill = Vector3.Distance(currentPosition, player.transform.position) <= standingThreshold;
            return isStandingStill;
        }
        public virtual void PetMove()
        {
            if (isFlying)
            {
                Fly();
            }
            else
            {
                MoveOnGround();
            }
            //   SyncPetRotationWithPlayer();
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
        public virtual void LookAtEnemy(Transform enemy)
        {
            if (enemy == null) return;

            Vector3 scale = transform.localScale;
            scale.x = enemy.localScale.x > 0 ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        public virtual void MoveOnGround()
        {

            petMove.Move(offsetX, 0);

        }


    }
}
