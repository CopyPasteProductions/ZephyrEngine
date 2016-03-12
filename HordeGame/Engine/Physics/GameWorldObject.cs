using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Collision;
using Microsoft.Xna.Framework;
using Engine.Physics.Movement;
using Engine.Physics.Collision.Interfaces;
using Engine.Physics.Action.Interfaces;

namespace Engine.Physics
{
    /// <summary>
    /// Game world object is the game world representation of a component
    /// </summary>
    public class GameWorldObject : IPhysics
    {

        int id;

        CollisionBody c;

        IOnCollision onCol;

        IMovement movement;



        public bool Enabled
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int UpdateOrder
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public void processFrame(GameTime gameTime)
        {
            if (movement.hasNextAction())
            {
                Console.WriteLine("has next action");
                movement.processNextAction(c, gameTime);
            }
            else
            {
                //otherwise do standard movement
                c.move();
            }

        }

        public GameWorldObject(CollisionBody ioc, IOnCollision ionC, IMovement m)
        {
            c = ioc;
            onCol = ionC;
            movement = m;
        }

        public void Update(GameTime gameTime)
        {
            //TODO make sure it doesn't update more than 60 times per second
            processFrame(gameTime);
        }

        public void addMovement(IMovement m)
        {
            foreach (IAction a in m.getMembers())
            {
                movement.addAction(a);
            }
        }

        public bool checkCollision(ICollidable st)
        {
            return c.isColliding(st.getCollisionBody());
        }

     

        public void endCurrentMovement()
        {
            movement.clear();
        }

        public void setMovementSeq(IMovement m)
        {
            movement = m;
        }

       

        public bool isActive()
        {
            //TODO fix thsi

            return true;
        }

        public Rectangle getDrawLocation()
        {
           return c.getDrawLocation();
        }

        public CollisionBody getCollisionBody()
        {
            return c;
        }

        public IOnCollision getCollisionAction()
        {
            return onCol;
        }
    }
}
