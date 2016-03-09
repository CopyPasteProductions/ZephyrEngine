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
     
        int Left {get;  }
           
        int Right{ get; }
        int Top { get;  }
        int Bottom { get; }

        bool isCollisionActive();

        bool isColliding(CollisionBody c);

        int getCollisionItemFor(CollisionBody c);

        List<Rectangle> getGeometry();

       
    }
}
