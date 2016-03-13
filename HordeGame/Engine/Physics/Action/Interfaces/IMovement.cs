using Engine.Physics.Collision.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Physics.Action.Interfaces
{
    public interface IMovement
    {
        void processNextAction(ref CollisionBody c, GameTime gameTime);

        bool hasNextAction();

        void addAction(IAction a);
        void clear();
        List<IAction> getMembers();
    }
}
