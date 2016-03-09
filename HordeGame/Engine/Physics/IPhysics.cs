using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.Physics.Action.Interfaces;
using Engine.Physics.Collision.Interfaces;

namespace Engine.Physics
{
    public interface IPhysics : IUpdateable, ICollidable
    {        
        void addMovement(IMovement m);

        void endCurrentMovement();

        void setMovementSeq(IMovement m);

        void processFrame(GameTime gameTime);

        IOnCollision getCollisionAction();
    }
}
