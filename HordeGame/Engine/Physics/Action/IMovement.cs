using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Physics.Action
{
    public interface IMovement
    {
        IAction getNextAction();

        bool hasNextAction();

        void addAction(IAction a);
    }
}
