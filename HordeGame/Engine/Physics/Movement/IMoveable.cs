using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Physics.Movement
{
    public interface IMoveable
    {
        Vector2 getMoveVector();
        /// <summary>
        /// Adds to the movement vector
        /// </summary>
        /// <param name="moveVector">Adds to the movement vector </param>
        void addMovement(Vector2 moveVector);
        /// <summary>
        /// Sets the movement vector to Zero
        /// </summary>
        void stopMovement();
        /// <summary>
        /// Moves the collision body based on the movement vector
        /// </summary>
        void step();
    }
}
