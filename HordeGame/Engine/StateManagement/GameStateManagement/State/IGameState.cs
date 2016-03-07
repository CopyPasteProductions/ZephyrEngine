using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.StateManagement.EntityManagement;
using Engine.StateManagement.EntityManagement.Entity;

namespace Engine.StateManagement.GameStateManagement.State
{
    public interface IGameState
    {
        //We should define what a game state is

        //Well what we know now is:
        //      A game state must be able to track user input.  IE move the mouse and stuff
        //          happens
        //      It must be able to draw images so that the visuals can be seen to be interacted
        //          with
        //      It must be able to update its own components in order to give feed back to the
        //          players.
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // So this makes me think the game state will require the following:
        // Entity Manager, Input Manager (I haven't written yet), Renderer
        //

        /// <summary>
        /// Does this state have entities attached to it
        /// </summary>
        /// <returns>Returns if there is at least one entity return true</returns>
        bool hasEntities();

        /// <summary>
        /// Can this State interact with the user?
        /// </summary>
        /// <returns></returns>
        bool hasInputManager();

        /// <summary>
        /// We want to update the states components
        /// </summary>
        IGameStateTransition updateState(GameTime gameTime);

        /// <summary>
        /// We have to be able to start the state to begin with
        /// </summary>
        void initialize();

        /// <summary>
        /// We have to draw the state
        /// </summary>
        /// <param name="gameTime"></param>
        void draw(GameTime gameTime);

        /// <summary>
        /// We have to be able to add an entity to the state
        /// </summary>
        /// <param name="e">The entity to be added</param>
        /// <returns>id assigned to submitted entity</returns>
        int addEntity(IEntity e);

        /// <summary>
        /// We may need to remove an Entity eventually
        /// </summary>
        /// <param name="e"></param>
        void removeEntity(IEntity e);

        /// <summary>
        /// Game states have name to identify them from each other.
        /// </summary>
        /// <returns>the name.</returns>
        string getName();
    }
}
