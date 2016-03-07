using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Engine.StateManagement.EntityManagement.Entity
{

    /// <summary>
    ///  Interface defining low level behavior expected of an entity
    /// 
    /// Alright So what is the definition of an Entity in this context?
    /// 
    /// My definition of entity is anything that requires updating,
    /// can be drawn or requires some sort of physics applied to it.
    /// 
    /// This interface is likely to expand eventually.
    /// </summary>
    public interface IEntity
    {
        //id used for looking up the entity
        int UniqueID { get; }

        //Thinking about it further wouldn't the position better be handled further up.
        //The thing is that position is required for all updates and colisions and even drawing.
        //position of the entity in the game world.
        // Point Position { get; set; }

        //Does this entity require updating?
        bool isUpdatable();

        //Does this entity required to be drawn?
        bool isDrawable();

        //so we have an internal draw object?  Lets get that.
        IDrawable getDrawable();

        //Can this entity be collided with
        bool isCollidable();

        //update the containing id
        void updateID(int newID);

        IUpdateable getUpdatable();

        //we need to be able to update the compenents of the entity
        void UpdateEntity(GameTime gameTime);
    }
}
