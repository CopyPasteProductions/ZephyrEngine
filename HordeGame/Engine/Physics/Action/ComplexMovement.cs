using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Collision.Interfaces;
using Microsoft.Xna.Framework;
using Engine.Physics.Action.Interfaces;
namespace Engine.Physics.Action
{
    public class ComplexMovement : IMovement
    {
        public void addAction(IAction a)
        {
            throw new NotImplementedException();
        }

        public void clear()
        {
            throw new NotImplementedException();
        }

        public List<IAction> getMembers()
        {
            throw new NotImplementedException();
        }

        public bool hasNextAction()
        {
            throw new NotImplementedException();
        }

        public void processNextAction(CollisionBody c, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
