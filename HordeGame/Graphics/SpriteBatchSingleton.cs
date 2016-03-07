using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HordeGame.Graphics
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
                    singleSpriteBatch = new SpriteBatch(Game1.Graphics.GraphicsDevice);
                }
                return singleSpriteBatch;
            }

                      
        }

    }
}
