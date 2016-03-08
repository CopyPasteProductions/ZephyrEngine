using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Engine.Physics.Collision.Interfaces
{
    /// <summary>
    /// This inteface will define the behavior of collisions
    /// An element implementing this will be able to determine whether it
    /// is colliding with another object.  Right now I'm planning on using rectangle based
    /// collisions but I may need to switch to perpixel or roll my own.
    /// </summary>
    public interface ICollidable
    {
        bool isActive();

        bool checkCollision(ICollidable c);

        CollisionBody getCollisionBody();

        void moveBody(Vector2 movement);
    }
}
