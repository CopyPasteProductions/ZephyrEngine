using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Graphics.ContentManager
{
    public interface IGameContentManager<T, K>
    {
        void loadContent(string name, K id);

        void unloadContent();

        T getContentById(K id);

    }
}
