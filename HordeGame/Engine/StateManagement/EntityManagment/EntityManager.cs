using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.StateManagement.EntityManagement.Entity;

namespace Engine.StateManagement.EntityManagement
{
    /// <summary>
    /// Interface defining the behaviour expected of an entity manager
    /// </summary>
    public interface EntityManager
    {
        //So what a entity manager will do is  basically manage all entities within the game.  An entity can be
        //anything from a Enemy Unit to the player itself as well as any projectiles or anything else.

        //My rational for having all data in one place is that when I want to add multiplayer I'm going to have to 
        //have a way to syncronize between all clients and this is my first thoughts at an approach to do that.

        //so saything that what should an entity manager be able to do.

        /// <summary>
        /// register an entity with the manager
        /// </summary>
        /// <param name="e"> The Entity you are registering</param>
        /// <returns>Integer representing the id of that Entity</returns>
        /// So the return value here is for the related element to later search for that entity
        int addEntity(IEntity e);

        /// <summary>
        /// Removes an Entity based on id
        /// </summary>
        /// <param name="id">The entity Id you want removed from the Manager</param>
        /// <returns>Removed Entity</returns>
        /// So if we can add an Entity we better be able to remove one.
        IEntity removeEntity(int id);

        //what if we want to just touch an entity?  CommandPattern?

        /// <summary>
        /// Gets all elements that can be updated
        /// </summary>
        /// <returns>Returns a Queue with all Entities that can be updated</returns>
        /// Alright so as part of the lifecycle of the Monogame Framework
        /// There are several phases to the framework one being the Update Phase which 
        /// pretty much is used to update the game components IE:  make something move or dynamically upgrade some graphics
        /// 
        Queue<IEntity> getUpdatables();

        /// <summary>
        /// Gets all elements that can be updated
        /// </summary>
        /// <returns>Returns a Queue with all Entities that can be drawn</returns>
        /// @See above
        Queue<IEntity> getDrawables();

        //TODO: document this in a bit.
        Queue<IEntity> getCollidables();
    }
}
