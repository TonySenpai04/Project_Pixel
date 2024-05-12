using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class UpMoveButton : MoveButton
    {
        public override void Start()
        {
            base.Start();
        }
        public override void Update()
        {
            if (isPressed)
            {
                movementController.MoveUp();
            }

        }
    }
}
