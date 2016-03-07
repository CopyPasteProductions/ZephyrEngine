using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.InputManager.InputType
{
    public class KeyboardInputEvent : IInputEvent
    {
        //Something to think about is if we would like to key the keys pressed since the last
        //update where all keyboard states can access?  I think so otherwise we may have large
        //numbers of keys being stored in memory
        //TODO: something to think about
        
        /// <summary>
        /// This is for determining when to reset the key timeout
        /// 10ms is too low probably
        /// </summary>
        const int keyTimeout = 10;
        bool triggered = false;
        string name;
        //TODO determine if there is a specific time frame to check
        //whether this needs updating.
        Double lastProcessTime = 0.0;
        Double lastUpdateTime = 0.0;
        Double triggeredTime = 0.0;
        int priorityNumber;

        Queue<Keys> pressedOrder;
        Queue<Keys> keySequence;

        public bool requireReleaseTrigger { get; private set; }

        public KeyboardInputEvent(Queue<Keys> orderedKeys, string name, int priorityNumber, bool requireRelease)
        {
            //@orderedKeys  This will be used to determined the sequence of key presses required to 
            //to trigger the event
            this.name = name;
            keySequence = orderedKeys;
            pressedOrder = new Queue<Keys>();
            this.priorityNumber = priorityNumber;
            this.requireReleaseTrigger = requireRelease;
        }


        public string getName()
        {
            return name;
        }

        public void process(GameTime gameTime)
        {
            //We need to handle delays and key released

            //I need to check whether there are keys pressed first

            KeyboardState kbstate = Keyboard.GetState();

            Keys[] pressedKeys = kbstate.GetPressedKeys();

            bool keysUpdated = false;
            //what if keys are being pressed that we don't care about?
            if (pressedKeys == null || pressedKeys.Length == 0)
            {
                keysUpdated = false;
                triggered = checkTriggerStatus();
            }
            else
            {
                
                foreach (Keys k in pressedKeys)
                {
                    //if the key is in the sequence we're looking at
                    if (keySequence.Contains(k))
                    {
                        keysUpdated = true;
                        pressedOrder.Enqueue(k);
                    }
                    //TODO: junk keys will probably have to be revisited.
                    //discard it otherwise
                }


            }

            //I could just call this method in the getter but caching it
            //could be faster later.
            //Should this even be called here anymore?
            if (!requireReleaseTrigger)
            {
                triggered = checkTriggerStatus();
            }
            //alright if the keys were not updated we need to consider
            //reseting the input watcher.
            if (!keysUpdated)
            {
                Double currentTime = gameTime.TotalGameTime.TotalMilliseconds;
                Double elapsedTimeSinceLastUpdate = currentTime - lastUpdateTime;
                if (elapsedTimeSinceLastUpdate > keyTimeout)
                {
                    reset();
                }
            }

        }

        private bool checkTriggerStatus()
        {
            //alright to check the trigger status we need to make sure that
            //the keys are in the same order.  TODO: do we want to allow partial matches?

            //This is a quick performance booster
            if (keySequence.Count < pressedOrder.Count)
            {
                //if the master has less keys then we are checking then we know
                //they can't be the same
                return false;
            }
            bool unmatched = true;
            //we need a copy of the keys that the play has pressed

            Queue<Keys> currentkeys = new Queue<Keys>(pressedOrder);



            //supports partial matches.
            foreach (Keys expected in keySequence)
            {
                Keys actual = currentkeys.Dequeue();

                if (!expected.Equals(actual))
                {
                    unmatched = false;
                    //we don't need to go any further than this.
                    break;
                }

            }


            return unmatched;
            
        }

        public void reset()
        {
            triggered = false;
            triggeredTime = 0.0;
            pressedOrder.Clear();
        }

        public bool isTriggered()
        {
            return triggered;
        }

        public int getPriorityNumber()
        {
            return priorityNumber;
        }

        public double getTriggeredTime()
        {
            return triggeredTime;
        }
    }
}
