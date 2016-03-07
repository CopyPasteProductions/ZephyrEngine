using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Collision;
using Engine.Physics.Movement;

namespace Engine.Physics.Action
{
    public class StopBodyAction : IAction
    {
        public void performAction(ref IMoveable m)
        {
            m.stopMovement();
        }
    }
}
