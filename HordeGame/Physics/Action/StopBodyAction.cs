using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Collision;
using Engine.Physics.Action;
using Engine.Physics.Movement;
using Engine.Physics.Action.Interfaces;
using Engine.Physics.Collision.Interfaces;
using Microsoft.Xna.Framework;

namespace HordeGame.Physics.Action
{
    public class StopBodyAction : IAction
    {
        public void performAction(ref CollisionBody c, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
