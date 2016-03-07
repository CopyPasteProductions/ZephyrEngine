using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.InputManager.InputType;
using Microsoft.Xna.Framework;

namespace Engine.InputManager
{
    public class ConcreteInputManager : IInputManager
    {
        List<IInputEvent> inputEvents;

        public ConcreteInputManager()
        {
            inputEvents = new List<IInputEvent>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IInputEvent> checkInputEvents()
        {
            var list = new List<IInputEvent>();

            /*foreach (IInputEvent i in inputEvents)
            {
                if (i.isTriggered())
                {
                    list.Add(i);
                    //what if its a one time thing like quick time event?
                    //Should I add some sort of remove call here?
                    //TODO: ^
                }


            }*/

            list.AddRange(inputEvents.Where(x => x.isTriggered()));

            return list;
        }

     

        public void registerInputEvent(IInputEvent i)
        {
            //Should I check if that event already exists?  Thats the reason I put the names in.

            inputEvents.Add(i);
        }

        public void removeInputEvent(IInputEvent i)
        {
            inputEvents.Remove(i);
        }

        public void updateInputEvents(GameTime gameTime)
        {
            foreach (IInputEvent i in inputEvents)
            {
                i.process(gameTime);
            }
        }

    }
}
