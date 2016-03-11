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
        private int drawOrder;
        private bool visible;
        private string textureName;
        private Rectangle destinationRectangle;

        public Sprite(int initDrawOrder, bool initVis, string textureName, Rectangle initLocation)
        {
            drawOrder = initDrawOrder;
            visible = initVis;
            this.textureName = textureName;
            destinationRectangle = initLocation;
        }

        public Sprite(string texture)
        {
            this.textureName = texture;
            this.destinationRectangle = new Rectangle(0, 0, 64, 64);
            drawOrder = 0;
            visible = true;
        }

        public int DrawOrder
        {
            get
            {
                return drawOrder;
            }
        }

        public bool Visible
        {
            get
            {
                return visible;
            }
        }

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public void updateDrawLocation(Rectangle r)
        {
            this.destinationRectangle = r;
        }

        public Rectangle getDrawLocation()
        {
            return this.destinationRectangle;
        }

        public void Draw(GameTime gameTime)
        {
            if (visible)
            {
                var text = ContentManager.ContentMangerSingleton.Textures.getContentById(textureName);
               
                    SpriteBatchSingleton.SingleSpriteBatch.Draw(text, getDrawLocation(), Color.White);
                
            }
        }
        //TODO: Implement tinting logic.

    }
}
