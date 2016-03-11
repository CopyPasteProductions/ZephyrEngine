using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics;
using Engine.Physics.Collision.Interfaces;
using Engine.Physics.Action.Interfaces;
using Microsoft.Xna.Framework;

namespace HordeGame.Physics
{
    public class OnCollisionScreenEdge : IOnCollision
    {
        IAction a = new ColisionWithEdgeScreen();

        public void onCollision(IPhysics currentUpdateBody, IPhysics bodyHitting, GameTime g)
        {
             
            //currentUpdateBody.addMovement();
        }
    }
}
