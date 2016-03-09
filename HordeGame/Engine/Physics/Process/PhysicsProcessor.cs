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


        public void clear()
        {
            gameObjects.Clear();
        }

        public void processFrame(GameTime gameTime)
        {
            gameObjects.OrderBy(x => x.UpdateOrder);

            foreach (GameWorldObject g in gameObjects)
            {
                g.processFrame(gameTime);
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
