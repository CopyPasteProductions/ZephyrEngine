using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Collision;
using Microsoft.Xna.Framework;

namespace Engine.Physics
{
    public class GameWorldObject : ICollidable
    {

        MovableRectangleCollisionBody phyicalPresence;

        public GameWorldObject(Point topLeft, Point widthHeight, bool col, Vector2 defaultMovement)
        {
            Rectangle r = new Rectangle(topLeft, widthHeight);
            phyicalPresence = new MovableRectangleCollisionBody(r, col, defaultMovement);
        }




        public bool checkCollision(ICollidable c)
        {
            throw new NotImplementedException();
        }

        public CollisionBody getCollisionBody()
        {
            throw new NotImplementedException();
        }

        public bool isCollidable()
        {
            throw new NotImplementedException();
        }

        public void moveBody(Vector2 movement)
        {
            throw new NotImplementedException();
        }
    }
}
