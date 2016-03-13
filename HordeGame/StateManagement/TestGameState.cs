using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.StateManagement.EntityManagement.Entity;
using Engine.StateManagement.GameStateManagement;
using Engine.StateManagement.GameStateManagement.State;
using Microsoft.Xna.Framework;
using Engine.StateManagement.EntityManagement;
using Engine.InputManager;
using Engine.Graphics.Renderer;
using Engine.Physics.Process;
namespace HordeGame.StateManagement
{
    public class TestGameState : IGameState
    {
        const string GAME_TEST = "test";
        private EntityManager entityManager;
        private GraphicsRenderer render;
        private PhysicsProcessor processor;

        public TestGameState(EntityManager e,  GraphicsRenderer g)
        {
            this.processor = new PhysicsProcessor();
            this.entityManager = e;
            this.render = g;
        }

        public int addEntity(IEntity e)
        {
            return entityManager.addEntity(e);
        }

        public void draw(GameTime gameTime)
        {
            foreach (IEntity e in entityManager.getDrawables())
            {
                Console.WriteLine("Found drawable");
                render.registerDrawable(e.getDrawable());
            }
            render.batchDraw(gameTime);

        }

        public string getName()
        {
            return GAME_TEST;
        }

        public bool hasEntities()
        {

            return true;
        }

        public bool hasInputManager()
        {
            throw new NotImplementedException();
        }

        public void initialize()
        {
          
        }

        public void removeEntity(IEntity e)
        {
            throw new NotImplementedException();
        }
        double lastDrawGameTime = 0.0;
        public IGameStateTransition updateState(GameTime gameTime)
        {
            var currentGameTime = gameTime.TotalGameTime.TotalMilliseconds;

            System.Console.WriteLine("Current draw" + currentGameTime);
            System.Console.WriteLine("last " + lastDrawGameTime);
            if (currentGameTime - lastDrawGameTime > 17 )
            {
               
          
          

            foreach (IEntity u in entityManager.getUpdatables())
            {
                IUpdateable element = u.getUpdatable();

                element.Update(gameTime);
               
            }
                processor.clear();
                foreach (IEntity e in entityManager.getCollidables())
            {
                    
                Console.WriteLine("Have Physics Objects");
                var col = e.Collidable;
                if (col.isActive())
                {
                    processor.registerPhysicsObject(ref col);
                }
            }
            Console.WriteLine("Processing game physics");
            processor.processFrame(gameTime);

                lastDrawGameTime = gameTime.TotalGameTime.TotalMilliseconds;
            }


      

          

            return null;
        }
    }
}
