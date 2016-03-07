using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.StateManagement.EntityManagement.Entity;

namespace Engine.Graphics.Renderer
{
    public interface GraphicsRenderer
    {
        /// <summary>
        /// We need to be able to unwrap the drawable
        /// </summary>
        /// <param name="d"></param>
        void registerDrawableEntity(IEntity d);

        void registerDrawable(IDrawable d);

        void batchDraw(GameTime gameTime);
    }
}
