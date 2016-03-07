using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Graphics
{
    public class Sprite : IDrawable
    {
        Texture2D spriteTexture;

        public int DrawOrder
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Visible
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        //TODO: Implement tinting logic.

    }
}
