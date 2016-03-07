using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Graphics.ContentManager;
namespace HordeGame.Graphics.ContentManager
{
    public class HordeGameContentLoader
    {
        private GenericContentManager<Texture2D> textures;

        public HordeGameContentLoader(ref GenericContentManager<Texture2D> c)
        {
            textures = c;
        }

        public void load()
        {
            //TODO:  add the majority of the content loading here
            textures.loadContent("Guy.png", "player");
        }


        public void unload()
        {
            textures.unloadContent();
        }


    }
}
