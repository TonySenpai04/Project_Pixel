using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class DownMoveButton : MoveButton
    {
        public override void Update()
        {
            if (isPressed)
            {
                movementController.MoveDown();
            }
           
        }
    }
}
