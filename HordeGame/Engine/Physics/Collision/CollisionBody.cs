using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Engine.Physics.Collision
{
   
    public interface CollisionBody
    {
        
        bool isCollisionActive();

        bool isColliding(CollisionBody c);

        int getCollisionItemFor(CollisionBody c);

        List<Rectangle> getGeometry();

       
    }
}
