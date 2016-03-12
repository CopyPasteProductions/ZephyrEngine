using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics;
using Engine.Physics.Collision.Interfaces;
using Engine.Physics.Action.Interfaces;
using Microsoft.Xna.Framework;
using Engine.Physics.Action;

namespace HordeGame.Physics
{
    public class OnCollisionScreenEdge : IOnCollision
    {
     

        public void onCollision(IPhysics currentUpdateBody, IPhysics bodyHitting, GameTime g)
        {
            IAction a = null;
            var m = new ComplexMovement();
            //I need to add the IAction to the movement.
            var hittingColBody = bodyHitting.getCollisionBody();
            if (hittingColBody.Left >= 782)
            {
                a = new ColisionWithEdgeScreen(ColisionWithEdgeScreen.ScreenSide.RIGHT);
            }
            else if (hittingColBody.Bottom <= 2)
            {
                a = new ColisionWithEdgeScreen(ColisionWithEdgeScreen.ScreenSide.TOP);
            }
            else if (hittingColBody.Top >= 479)
            {
                a = new ColisionWithEdgeScreen(ColisionWithEdgeScreen.ScreenSide.BOT);
            }
            else if (hittingColBody.Left <= 1)
            {
                a = new ColisionWithEdgeScreen(ColisionWithEdgeScreen.ScreenSide.LEFT);

            }


            if (a != null)
            {
                m.addAction(a);
                currentUpdateBody.setMovementSeq(m);
                currentUpdateBody.processFrame(g);
            }
            
        }
    }
}
