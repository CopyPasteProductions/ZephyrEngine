using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.Physics.Movement;
namespace Engine.Physics.Collision.Interfaces
{
   
    public interface CollisionBody : IMoveable 
    {
        
        bool isCollisionActive();

        bool isColliding(CollisionBody c);

        int getCollisionItemFor(CollisionBody c);

        List<Rectangle> getGeometry();

       
    }
}
