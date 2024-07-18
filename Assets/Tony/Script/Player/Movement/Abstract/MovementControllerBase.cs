using UnityEngine;

namespace Tony
{
    public abstract class MovementControllerBase:MonoBehaviour
    {
        [SerializeField] protected HeroAnimationControllerBase heroAnimationController;
        public virtual void Start()
        {
            
        }

        public virtual void Update()
        {

        }
        public abstract void MoveLeft();
        public abstract void MoveRight();

        public abstract void Jump();


        public abstract void MoveDown();
        public abstract void MoveUp();

        public abstract void StopMovement();
    }
}