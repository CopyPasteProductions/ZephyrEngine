using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Engine.StateManagement.EntityManagement.Entity;
using Engine.Physics;

namespace Engine.StateManagement.EntityManagement.Entity
{
    public class AbstractEntity : IEntity
    {
        //Alright we want to start keeping track of the Id for the entity manager.
        int myIdentifier;

        public AbstractEntity(int myIdentifier)
        {
            //we want the ID to only be set once.  
            this.myIdentifier = myIdentifier;
        }

        public AbstractEntity()
        {
            //I'm not sure if an Entity should be instantiated with an ID
            //Why?  Because more than likely I'll have to assign the id when the entity is added to the manager

        }
              
        //should these be further up the chain?  Thinking about it it has to be at this level for 
        //the concept of polymorphism to work.  But it will be acceptable to leave these elements to 
        //throw exceptions because this is a superclass of the final entity.  In reality rather than using 
        //placeholder veriables these should be methods.


        int IEntity.UniqueID
        {
            get
            {
                return myIdentifier;
            }
                        
        }

       

        public GameWorldObject Collidable
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual bool isCollidable()
        {
            throw new NotImplementedException();
        }


        public virtual bool isDrawable()
        {
            throw new NotImplementedException();
        }



        public virtual bool isUpdatable()
        {
            throw new NotImplementedException();
        }

        public void updateID(int newID)
        {
            
            myIdentifier = newID;
        }

        public virtual IDrawable getDrawable()
        {
            throw new NotImplementedException();
        }

        public virtual IUpdateable getUpdatable()
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateEntity(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
