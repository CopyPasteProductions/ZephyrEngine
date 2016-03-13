using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Physics.Helpers
{
    public class CollisionHelper
    {
        static bool isBetweenTwoValues(int i, int value1, int value2)
        {
            if (value1 > value2)
            {
                //value1 is greater so we check against value2
                return i > value2;
            }
            else if (value2 > value1)
            {
                return i > value1;
            }
            else
            {
                return false;
            }

        }
    }
}
