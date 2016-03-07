using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Engine.StateManagement.EntityManagement.Entity;

namespace Engine.Graphics.Renderer
{
    /// <summary>
    /// This object handling the rendering so that everything rendered at the same time.  Instead of ones and twos
    /// </summary>
    public class GraphicsQueueRenderer : GraphicsRenderer
    {
        private Queue<IDrawable> drawTargets;

        public GraphicsQueueRenderer()
        {

        }
        /// <summary>
        /// The goal of this method is to draw the elements registered in batches.
        /// </summary>
        /// <param name="gameTime"></param>
        public void batchDraw(GameTime gameTime)
        {
            var spritebatch = SpriteBatchSingleton.SingleSpriteBatch;
            //order by draw order.  
            //TODO: Verify that this does the proper ordering
            drawTargets.OrderBy(x => x.DrawOrder);
            var drawElements = new Queue<IDrawable>(drawTargets);
            Console.WriteLine("Number of drawElements = " + drawElements.Count);
            spritebatch.Begin();
            //okay now we need to iterate based on draw order and draw each element.
            foreach (IDrawable element in drawElements)
            {
                //tell the element to draw itself.
                element.Draw(gameTime);
            }

            spritebatch.End();

            //we now need to clear the queue elements.
            drawTargets.Clear();
        }

        public void registerDrawable(IDrawable d)
        {
            if (drawTargets == null)
            {
                drawTargets = new Queue<IDrawable>();
            }

            drawTargets.Enqueue(d);
        }

       public void registerDrawableEntity(IEntity d)
        {
            if (d.isDrawable())
            {
                registerDrawable(d.getDrawable());
            }
        }
    }
}
