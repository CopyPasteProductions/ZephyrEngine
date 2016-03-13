using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Collision;
using Engine.Physics.Movement;
using Microsoft.Xna.Framework;
using Engine.Physics.Collision.Interfaces;

namespace Engine.Physics.Action.Interfaces
{
    public interface IAction
    {
        void performAction(ref CollisionBody c, GameTime gameTime);
       
    }
}
