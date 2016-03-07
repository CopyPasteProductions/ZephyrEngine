using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.StateManagement.GameStateManagement.State;
using Microsoft.Xna.Framework;

namespace Engine.StateManagement.GameStateManagement
{
    //TODO:  Go over Exception Handling.
    public class ConcreteGameStateManager : IGameStateManager
    {
        IGameState activeGameState;

        Dictionary<string, IGameState> gameStates;

        bool initialized = false;
        private string defaultStateName;

        public ConcreteGameStateManager()
        {
            gameStates = new Dictionary<string, IGameState>();
        }

        public ConcreteGameStateManager(string v)
        {
            this.defaultStateName = v;
            gameStates = new Dictionary<string, IGameState>();
        }

        public void addGameState(IGameState g)
        {
            gameStates.Add(g.getName(), g);
        }

        public void changeActiveGameState(string name)
        {
            IGameState outValue;
            gameStates.TryGetValue(name, out outValue);

            activeGameState = outValue;
        }

        public IGameState getActiveGameState()
        {
            //I should be returning the name here...
            //TODO: make this safer.
            return activeGameState;
        }

        public void init()
        {
            //we need to initialize our components
            foreach(string key in gameStates.Keys)
            {
                IGameState g;
                gameStates.TryGetValue(key, out g);
                g.initialize();
            }
            if (defaultStateName != null)
            {
               this.changeActiveGameState(defaultStateName);
            }
            this.initialized = true;
        }

        public IGameStateTransition updateActiveGameState(GameTime gameTime)
        {
            if (!initialized)
            {

                return null;
            }

            return activeGameState.updateState(gameTime);
       }

        public void removeGameState(string g)
        {
            //I should throw an exception here.
            gameStates.Remove(g);
        }

        public void drawGameStateComponents(GameTime gameTime)
        {
            activeGameState.draw(gameTime);
        }
    }
}
