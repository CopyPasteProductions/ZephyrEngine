using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.Physics.Collision.Interfaces;

namespace Engine.Physics.Collision
{
    public class SimpleCollisionBody : CollisionBody
    {
        protected Rectangle body;
        Vector2 acceleration;

        bool collidable;

        public int Left
        {
            get
            {
                return body.Left;
            }

           
        }

        public int Right
        {
            get
            {
                return body.Right;
            }

           
        }

        public int Top
        {
            get
            {
                return body.Top;
            }

           
        }

        public int Bottom
        {
            get
            {
                return body.Bottom;
            }

            
        }

        public SimpleCollisionBody(Rectangle body, bool collidable)
        {
            this.body = body;
            this.collidable = collidable;
            this.acceleration = Vector2.Zero;
        }


        public bool isColliding(CollisionBody c)
        {
            foreach(Rectangle r in c.getGeometry())
            {
                // if I intersect r return true
                if (body.Intersects(r))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Rectangle> getGeometry()
        {
            var list = new List<Rectangle>();
            list.Add(body);

            return list;
        }

        public bool isCollisionActive()
        {
            return collidable;
        }

        public int getCollisionItemFor(CollisionBody c)
        {
            if (this.isColliding(c))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public Vector2 getAcceleration()
        {
            return acceleration;
        }

        public void setAcceleration(Vector2 moveVector)
        {
            Console.WriteLine("Setting Acceleration: " + moveVector);
            acceleration = moveVector;
        }

        public void resetAcceleration()
        {
            acceleration = Vector2.Zero;
        }

        public void move()
        {
            //shift the top left based on the acceleration
            body.X += (int)acceleration.X;
            body.Y += (int)acceleration.Y;
        }

        public void addAcceleration(Vector2 accelerationFactor)
        {
            acceleration = Vector2.Add(acceleration, accelerationFactor);
        }

        public void setPosition(Point targetLocation)
        {
            body.X = targetLocation.X;
            body.Y = targetLocation.Y;
        }

        public Rectangle getDrawLocation()
        {
            return body;
        }
    }
}
