using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Engine.Graphics
{
   public class SpriteBatchSingleton
    {

        private static SpriteBatch singleSpriteBatch;

        public static SpriteBatch SingleSpriteBatch
        {
            get
            {
                if (singleSpriteBatch == null)
                {
                    //singleSpriteBatch = new SpriteBatch(Game1.Graphics.GraphicsDevice);
                }
                return singleSpriteBatch;
            }

                      
        }

        //TODO: hack this so I can get it work properly
        public static void setSpriteBatch(SpriteBatch s)
        {
            singleSpriteBatch = s;
        }
    }
}
