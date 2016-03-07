using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.StateManagement.GameStateManagement.StateTransition
{
    public class ChangeStateTransition : IGameStateTransition
    {
        string targetStateName;

        public ChangeStateTransition(String stateNameToChangeTo)
        {
            targetStateName = stateNameToChangeTo;
        }


        /// <summary>
        /// Modify the state of the passed in manager
        /// </summary>
        /// <param name="manager">Game state manager.</param>
        public void performActionOnGameStateManager(ref IGameStateManager manager)
        {
            manager.changeActiveGameState(targetStateName);

        }
    }
}
