using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
namespace Engine.Graphics
{
    public static class EngineMonoGameSingleTon
    {
        private static Microsoft.Xna.Framework.Content.ContentManager contentManager;

        public static Microsoft.Xna.Framework.Content.ContentManager ContentManager
        {
            get
            {
                return contentManager;
            }

        }

        public static void init(Microsoft.Xna.Framework.Content.ContentManager contenManager)
        {
            contentManager = contenManager;
        }

    }
}
