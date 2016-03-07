using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Graphics.ContentManager;
namespace HordeGame.Graphics
{
    public class Sprite : IDrawable
    {
        GenericContentManager<Texture2D> content;
        string name;
        //TODO: Implement tinting logic.
        int x, y;
        public Sprite(string textureName, GenericContentManager<Texture2D> contentManager, int x, int y)
        {
            name = textureName;
            this.content = contentManager;
            this.x = x;
            this.y = y;
          }
        
        int IDrawable.DrawOrder
        {
            get
            {
                return 1;
            }
        }

        bool IDrawable.Visible
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IDrawable.DrawOrderChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<EventArgs> IDrawable.VisibleChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        
        public void Draw(GameTime gameTime)
        {
            
            Engine.Graphics.SpriteBatchSingleton.SingleSpriteBatch.Draw(content.getContentById(name), new Rectangle(new Point(x, y), new Point(64, 64)), Color.White);
        }

        public void printTargetLocation()
        {
            Console.WriteLine(x + ", " + y + ", 64, 64");
        }
    }
}
