using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Action.Interfaces;
using Engine.Physics.Collision.Interfaces;
using Microsoft.Xna.Framework;

namespace HordeGame.Physics
{
    public class ColisionWithEdgeScreen : IAction
    {
       public enum ScreenSide { TOP, BOT, LEFT, RIGHT};

        ScreenSide side;
        public ColisionWithEdgeScreen(ScreenSide side)
        {
            this.side = side;
        }
        public void performAction(CollisionBody c, GameTime gameTime)
        {
            var acceleration = c.getAcceleration();

            Vector2 sideVector;
            switch (side)
            {
                case ScreenSide.TOP:
                    sideVector = new Vector2(1, 0);
                    break;
                case ScreenSide.BOT:
                    sideVector = new Vector2(1, 0);
                    break;
                case ScreenSide.LEFT:
                    sideVector = new Vector2(0,1);
                    break;
                case ScreenSide.RIGHT:
                    sideVector = new Vector2(0, 1);
                    break;
               default:
                    sideVector = Vector2.Zero;
                    break;
            }

            var result = Vector2.Reflect(acceleration, sideVector);

            c.setAcceleration(result);
        }
    }
}
