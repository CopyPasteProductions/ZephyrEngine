using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Physics.Movement
{
    public interface IMoveable
    {
        Vector2 getAcceleration();
        /// <summary>
        /// Adds to the movement vector
        /// </summary>
        /// <param name="moveVector">Adds to the movement vector </param>
        void setAcceleration(Vector2 moveVector);
        /// <summary>
        /// Sets the movement vector to Zero
        /// </summary>
        void resetAcceleration();
        /// <summary>
        /// Moves based on the movement vector
        /// </summary>
        void move();

        void setPosition(Point targetLocation);

        void addAcceleration(Vector2 accelerationFactor);
    }
}
