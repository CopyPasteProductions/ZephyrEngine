using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Movement;
using Engine.Physics.Collision.Interfaces;
using Microsoft.Xna.Framework;
namespace Engine.Physics.Collision.Interfaces
{
    public interface IOnCollision
    {
        //adds movement to both IPhysics objects.
        void onCollision(IPhysics currentUpdateBody, IPhysics bodyHitting, GameTime g);

    }
}
