using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Collision;
using Engine.Physics.Action;
using Engine.Physics.Movement;

namespace HordeGame.Physics.Action
{
    public class StopBodyAction : IAction
    {
        public void performAction(ref IMoveable c)
        {
            c.stopMovement();
        }
    }
}
