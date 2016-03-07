using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.StateManagement.EntityManagement;
using Engine.StateManagement.EntityManagement.Entity;

namespace Engine.StateManagement.EntityManagement
{
    //note: not thread safe
    public class GameElementEntityManager : EntityManager
    {
        //For the internal structure of the Entity Manager we're going to use
        //a dictionary.  This dictionary will be used to look up an element in the structure.
        //if it turns out that its snow we may need to convert to a list to speed things up.
        Dictionary<int, IEntity> entities;
        int lastId = 1;

        public GameElementEntityManager()
        {
            entities = new Dictionary<int, IEntity>();
        }


        public int addEntity(IEntity e)
        {
            //alright we need to add a entity to the game.
            if (entities == null)
            {
                entities = new Dictionary<int, IEntity>();
            }
            // we want to get the entities id and add it to the hashmap, now what happens if it doesn't have 
            //an id?
            if (e.UniqueID == 0)
            {
                //this also removes the chance of duplicated keys!!!
                //get the next available key!
                int id = getNextAvailableID();
                e.updateID(id);
                entities.Add(id, e);
                return id;
            }
            else
            {
                entities.Add(e.UniqueID, e);
                return e.UniqueID;
            }
        }

        /// <summary>
        /// This method is used to auto assign ids if needed
        /// </summary>
        /// <returns>
        /// unique id
        /// </returns>
        private int getNextAvailableID()
        {
            var newId = lastId;
            //increment lastID 
            lastId++;
            return newId;
        }

        Queue<IEntity> EntityManager.getCollidables()
        {
            throw new NotImplementedException();
        }

        Queue<IEntity> EntityManager.getDrawables()
        {
            Queue<IEntity> qEntities = new Queue<IEntity>();
            //I feel like I should be able to use lamda here
            foreach (IEntity e in entities.Values)
            {
                if (e.isDrawable())
                {
                    qEntities.Enqueue(e);
                }
            }
            //its okay if these are readonly ie return byval
            return qEntities;
        }

        Queue<IEntity> EntityManager.getUpdatables()
        {
            var q = new Queue<IEntity>();

            foreach (int key in entities.Keys)
            {
                if (entities[key].isUpdatable())
                {
                    q.Enqueue(entities[key]);
                }
            }

            return q;
        }

        public IEntity removeEntity(int id)
        {
            IEntity i = null;
            
            var found = entities.TryGetValue(id, out i);
            if(found) entities.Remove(id);
            return i;
        }
    }
}
