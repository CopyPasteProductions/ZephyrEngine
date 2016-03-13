using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Engine.Physics;
using Engine.Physics.Collision;
using Engine.StateManagement.EntityManagement.Entity;
using Engine.Physics.Movement;
using Engine.Graphics;

namespace Engine.StateManagement.EntityManagement.Entity
{
    /// <summary>
    /// So the concreteEntity is actually what is added to an Entity Manager.
    /// 
    /// 
    /// </summary>
    public class ConcreteEntity : AbstractEntity
    {
        //So what was the purpose of abstracting this out?
        //The purpose is to allow us to have a flexible base entity
        //that we can put any sort of game element in


        Sprite drawable;
        IUpdateable updatable;
        GameWorldObject gameWorldRepresentation;

        //encapsulations
        public Sprite Drawable
        {
            get
            {
                return drawable;
            }

            set
            {
                drawable = value;
            }
        }

        public IUpdateable Updatable
        {
            get
            {
                return updatable;
            }

            set
            {
                updatable = value;
            }
        }

        public override GameWorldObject Collidable
        {
            get
            {
                return gameWorldRepresentation;
            }

            set
            {
                gameWorldRepresentation = value;
            }
        }

        public ConcreteEntity(Sprite drwbl, IUpdateable updble, GameWorldObject colidble)
        {
            //pretty standard stuff here
            Drawable = drwbl;
            Updatable = updble;
            Collidable = colidble;
        }


        public override bool isCollidable()
        {
            //okay if we don't have a collidable we know that we
            //can't collide with anything
            return gameWorldRepresentation != null;
        }

        public override bool isDrawable()
        {
            //as with collidable we just need to check to see if
            //its null
            return Drawable != null;
        }

        public override bool isUpdatable()
        {
            //as with collidable we just need to check to see if
            //its null
            return Updatable != null;
        }

        public override IDrawable getDrawable()
        {
            drawable.updateDrawLocation(gameWorldRepresentation.getDrawLocation());
            return drawable;
        }

        public override IUpdateable getUpdatable()
        {
            return updatable;
        }

        public override void UpdateEntity(GameTime gameTime)
        {
            //this.updatable.Update(gameTime);
            //I'm thinking this may not be needed.
        }
    }
}
