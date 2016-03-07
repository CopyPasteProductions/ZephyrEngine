using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Engine.InputManager.InputType
{
    public interface IInputEvent
    {
        /// <summary>
        /// If the event was triggered since the last update we need to let them know
        /// </summary>
        /// <returns></returns>
        bool isTriggered();
        /// <summary>
        /// We need to allow the event to be checked during the lifecycle
        /// I could just inherit IUpdatable but I don't want to bloat this interface
        /// </summary>
        void process(GameTime gameTime);

        /// <summary>
        /// We need to be able to reset the event
        /// </summary>
        void reset();

        /// <summary>
        /// An event should have a unique identitifier
        /// </summary>
        /// <returns>name of the event</returns>
        string getName();

        //I feel like we should have some sort of action possibly returned
        //from this level.  I'll visit the idea later TODO: ^

        /// <summary>
        /// What if a number of events are thrown from the 
        /// input handler at once?
        /// </summary>
        /// <returns></returns>
        int getPriorityNumber();

        /// <summary>
        /// If two priority numbers are the same the earlier trigger time gets processed
        /// </summary>
        /// <returns>Millis</returns>
        double getTriggeredTime();

        //What if a input event wants you to cancel all other triggers?
    }
}
