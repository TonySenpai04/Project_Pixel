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
            btn.onClick.AddListener(movementController.Jump);
        }
    }
}
