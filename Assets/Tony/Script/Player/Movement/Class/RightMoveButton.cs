using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class RightMoveButton : MoveButton
    {
        public override void Update()
        {
            if (isPressed)
            {
                playerController.MoveRight();
            }
            
        }
    }
}
