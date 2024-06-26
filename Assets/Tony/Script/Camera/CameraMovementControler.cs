using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony {
    public class CameraMovementControler : MonoBehaviour
    {
        private IMove cameraFollow;
        [SerializeField] private Transform player;
        [SerializeField] private Vector3 offset;


        void Start()
        {
            InitializeVariables();
        }
        public void InitializeVariables()
        {
            cameraFollow = new CameraMovement(this.player, this.gameObject, this.offset);

        }
        void Update()
        {
            cameraFollow.Move(0,0);

        }
    }
}
