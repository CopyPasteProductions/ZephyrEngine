using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Engine.Physics.Collision
{
    public class RectangleCollisionBody : CollisionBody
    {
        protected Rectangle body;
        
        bool collidable;
        public RectangleCollisionBody(Rectangle body, bool collidable)
        {
            this.body = body;
            this.collidable = collidable;
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

    }
}
