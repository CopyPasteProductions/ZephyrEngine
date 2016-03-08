using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.Physics.Collision;

namespace Engine.Physics.Process
{
    public interface IPhysicsProcessor
    {
        //What opperations should a physics processor do?
        //first it should collect a collision objects 

        //Then it should perform a step operation on all objects that can move
        //Then it should process collision action items.  If an item has a complex action attached to it
        //it should track that object and perform the complex actions steps.

        //it should keep track of the environment items that effect the processing of physics events.   

        void processFrame();

        void registerPhysicsObject(ref GameWorldObject o);

        void removePhysicsObject(int id);

        void clear();

    }
}
