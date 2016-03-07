using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.InputManager.InputType;
using Microsoft.Xna.Framework;

namespace Engine.InputManager
{
    public interface IInputManager
    {
        //Lets define the behavior of a an input manager!
        //My thought process states that an Input manager will have a series of 
        //inputs that it will check if triggered.  If those inputs have been access 
        //it will register true and then we know to handle that input.
        //So we should define an input type first.

        /// <summary>
        /// We have to let them add InputEvents
        /// </summary>
        /// <param name="i">input event</param>
        void registerInputEvent(IInputEvent i);

        /// <summary>
        /// This method looks for triggered events 
        /// </summary
        /// <returns>A lists of triggered events</returns>
        List<IInputEvent> checkInputEvents();

        /// <summary>
        /// We probably will want to be able to remove an event
        /// </summary>
        /// <param name="i"></param>
        void removeInputEvent(IInputEvent i);

        /// <summary>
        /// Calls the update on the InputEvents
        /// </summary>
        /// <param name="i"></param>
        void updateInputEvents(GameTime gameTime);

      
    }
}
