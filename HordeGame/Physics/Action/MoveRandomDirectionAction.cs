using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Action.Interfaces;
using Engine.Physics.Collision.Interfaces;
using Microsoft.Xna.Framework;

namespace HordeGame.Physics.Action
{
    public class MoveRandomDirectionAction : IAction
    {
        public void performAction(ref CollisionBody c, GameTime gameTime)
        {
            Random random = new Random();
            var accelleration = new Vector2(0, 4);
            Console.WriteLine(accelleration);
            c.addAcceleration(accelleration);

        }
    }
}
