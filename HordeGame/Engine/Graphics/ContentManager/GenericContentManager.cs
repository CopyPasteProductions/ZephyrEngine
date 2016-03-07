using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Graphics.ContentManager
{
   
    public class GenericContentManager<T> : IGameContentManager<T, String>
    {
        private static Microsoft.Xna.Framework.Content.ContentManager content;

        private Dictionary<String, T> objs;

        public GenericContentManager(ref Microsoft.Xna.Framework.Content.ContentManager c)
        {
            content = c;
            objs = new Dictionary<String, T>();
        }

        public T getContentById(String id)
        {
            T returnValue;
            objs.TryGetValue(id, out returnValue);
            return returnValue;
        }

        public void loadContent(string name, String id)
        {
            T itemToBeLoaded = content.Load<T>(name);

            objs.Add(id, itemToBeLoaded);
            
        }

        public void unloadContent()
        {
            if (objs.Count == 0)
            {
                return;
            }
            content.Unload();
            
        }
    }
}
