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
        CollisionBody c;

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

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public void processFrame(GameTime gameTime)
        {
            if (movement.hasNextAction())
            {
                movement.processNextAction(c, gameTime);
            }
            else
            {
                //otherwise do standard movement
                c.move();
            }

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

        

        public CollisionBody getCollisonBody()
        {
            return c;
        }

        public void endCurrentMovement()
        {
            movement.clear();
        }

        public void setMovementSeq(IMovement m)
        {
            movement = m;
        }
    }
}
