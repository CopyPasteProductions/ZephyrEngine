using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Process.Interfaces;
using Microsoft.Xna.Framework;

namespace Engine.Physics.Process
{
    public class PhysicsProcessor : IPhysicsProcessor
    {
        LinkedList<GameWorldObject> gameObjects;

        public PhysicsProcessor()
        {
            gameObjects = new LinkedList<GameWorldObject>();
        }

        public void clear()
        {
            gameObjects.Clear();
        }

        public void processFrame(GameTime gameTime)
        {
            gameObjects.OrderBy(x => x.UpdateOrder);
            //pre move before checking collisions
            foreach (GameWorldObject g in gameObjects)
            {
                g.processFrame(gameTime);
                
            }

            foreach (GameWorldObject g in gameObjects)
            {
                foreach (GameWorldObject o in gameObjects)
                {
                    if (g == o)
                    {
                        continue;
                    }
                    else if (g.checkCollision(o))
                    {
                        var col = g.getCollisionAction();
                        if (col != null)
                        {
                            col.onCollision(g, o);
                        }
                        else
                        {
                            //do nothing
                        }
                        
                    }


                }

            }
            

        }

        public void registerPhysicsObject(ref GameWorldObject o)
        {
            if(gameObjects == null)
            {
                gameObjects = new LinkedList<GameWorldObject>();
            }
            gameObjects.AddLast(o);
        }

        public void removePhysicsObject(int id)
        {
            foreach(GameWorldObject g  in gameObjects.Where(x => x.Id == id))
                {
                    gameObjects.Remove(g);
                }
        }
    }
}
