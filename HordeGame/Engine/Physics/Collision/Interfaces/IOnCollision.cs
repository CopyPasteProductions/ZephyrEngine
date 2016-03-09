using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Physics.Movement;
using Engine.Physics.Collision.Interfaces;

namespace Engine.Physics.Collision.Interfaces
{
    public interface IOnCollision
    {

        void onCollision(IPhysics currentUpdateBody, IPhysics bodyHitting);

    }
}
