using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.StateManagement.GameStateManagement
{
    public interface IGameStateTransition
    {

        /// <summary>
        /// We need to be able to change the game state of 
        /// the manager.  The best way I could think of was to
        /// use the command pattern.
        /// </summary>
        /// <param name="manager">game state manager that will be modified.</param>
        void performActionOnGameStateManager(ref IGameStateManager manager);
    }
}
