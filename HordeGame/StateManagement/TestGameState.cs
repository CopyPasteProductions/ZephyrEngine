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

        public IGameStateTransition updateState(GameTime gameTime)
        { 
            foreach (IEntity u in entityManager.getUpdatables())
            {
                IUpdateable element = u.getUpdatable();

                element.Update(gameTime);
               
            }

            foreach (IEntity e in entityManager.getCollidables())
            {
                var col = e.Collidable;
                if (col.isActive())
                {
                    processor.registerPhysicsObject(ref col);
                }
            }

            processor.processFrame(gameTime);



            foreach (IEntity e in entityManager.getDrawables())
            {
                render.registerDrawable(e.getDrawable());
            }

          

            return null;
        }
    }
}
