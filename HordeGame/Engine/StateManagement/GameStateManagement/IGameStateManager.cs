using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.StateManagement.GameStateManagement.State;
namespace Engine.StateManagement.GameStateManagement
{
    /// <summary>
    /// A game state manager actually does all the work required to run the game
    /// updates components and what not.  
    /// </summary>
    public interface IGameStateManager
    {
        /// <summary>
        /// Initialize the Gamestate manager
        /// </summary>
        void init();

        /// <summary>
        /// Process the active game state
        /// </summary>
        /// <param name="gameTime"></param>
        IGameStateTransition updateActiveGameState(GameTime gameTime);

        IGameState getActiveGameState();

        void drawGameStateComponents(GameTime gameTime);

        void addGameState(IGameState g);

        void removeGameState(string name);

        void changeActiveGameState(string name);



    }            
}
