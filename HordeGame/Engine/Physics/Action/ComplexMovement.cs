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
        Queue<IAction> actionFrames;

        public ComplexMovement()
        {
            actionFrames = new Queue<IAction>();
        }

        public void addAction(IAction a)
        {
            actionFrames.Enqueue(a);
        }

        public void clear()
        {
            actionFrames.Clear();
        }

        public List<IAction> getMembers()
        {
            //TODO Implement this.
            return new List<IAction>();
        }

        public bool hasNextAction()
        {
            return actionFrames.Count > 0;
        }

        public void processNextAction(ref CollisionBody c, GameTime gameTime)
        {
            //TODO FRAMELOCKING
            //Lets grab the next action!
            var action = actionFrames.Dequeue();

            action.performAction(ref c, gameTime);

        }
    }
}
