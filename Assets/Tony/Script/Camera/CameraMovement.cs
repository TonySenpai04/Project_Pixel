using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tony
{
    public class CameraMovement : IMove
    {

        private Transform player;
        private GameObject camera;
        private Vector3 offset;
        public CameraMovement(Transform player, GameObject camera, Vector3 offset)
        {
            this.player = player;
            this.camera = camera;
            this.offset = offset;
        }

        public void Move(float x, float y)
        {
            if (player != null)
            {
                Vector3 pos = player.transform.position;
                pos.x = player.position.x + offset.x;
                pos.y = player.position.y + offset.y;
                pos.z = camera.transform.position.z;
                camera.transform.position = pos;
            }
        }
    }
}
