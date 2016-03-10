using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Graphics.ContentManager
{
    public static class ContentMangerSingleton
    {
        private static GenericContentManager<Texture2D> textures;

        public static GenericContentManager<Texture2D> Textures
        {
            get
            {
                if (textures == null)
                {
                    var cm = Engine.Graphics.EngineMonoGameSingleTon.ContentManager;
                    textures = new GenericContentManager<Texture2D>(ref cm);
                }
                return textures;
            }

        }
    }
}
