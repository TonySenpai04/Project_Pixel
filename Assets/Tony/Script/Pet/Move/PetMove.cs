
using UnityEngine;
namespace Tony
{
    internal class PetMove : IMove
    {
        private GameObject pet;
        private Transform player;
        private float moveSpeed;

        public PetMove(GameObject pet, Transform player, float moveSpeed)
        {
            this.pet = pet;

            this.player = player;
            this.moveSpeed = moveSpeed;
        }
        public void Move(float x, float y)
        {
            //Vector3 targetPosition;

            //targetPosition = player.position + new Vector3(-x, y, 0);

            //pet.transform.position = Vector3.Lerp(pet.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            Vector3 targetPosition;

            // Adjust the offset based on the player's facing direction
            if (player.localScale.x > 0)
            {
                // Player is facing right
                targetPosition = player.position + new Vector3(-x, y, 0);
            }
            else
            {
                // Player is facing left
                targetPosition = player.position + new Vector3(x, y, 0);
            }

            pet.transform.position = Vector3.Lerp(pet.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

    }
}