using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Collision;
using Engine.Physics.Movement;
using Microsoft.Xna.Framework;

namespace Engine.Physics
{
    public class MovableRectangleCollisionBody : SimpleCollisionBody, IMoveable
    {
        Vector2 moveVector;

        public MovableRectangleCollisionBody(Rectangle body, bool collidable, Vector2 defaultMovement) : base(body, collidable)
        {
            moveVector = defaultMovement;
        }


        
        public Vector2 getAcceleration()
        {
            return moveVector;
        }

        public void setAcceleration(Vector2 moveVector)
        {
            this.moveVector += moveVector;
        }

        public void move()
        {
            body.X += (int)moveVector.X;
            body.Y += (int)moveVector.Y;
        }

        public void resetAcceleration()
        {
            this.moveVector = Vector2.Zero;
        }
    }
}
