using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tony
{
    public class LeftMoveButton : MoveButton
    {
        public override void Update()
        {
           if(isPressed)
           {
                movementController.MoveLeft();
           }
           
        }
    }
}
