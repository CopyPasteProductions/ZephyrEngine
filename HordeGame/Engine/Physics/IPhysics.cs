using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.Physics.Action.Interfaces;
namespace Engine.Physics
{
    public interface IPhysics : IUpdateable
    {        
        void addMovement(IMovement m);

        void endCurrentMovement();

        void setMovementSeq(IMovement m);

        void processFrame(GameTime gameTime);


    }
}
