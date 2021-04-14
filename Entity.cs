using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace UpdatedEngine2
{
    public abstract class Entity : IEntity, ICollidable, IInput
    {
        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void Update()
        {

        }

        public virtual void Texture()
        {

        }

        public virtual void Position()
        {
            
        }

        public virtual void HitBox()
        {

        }

        public virtual void OnCollide(IEntity entityCol)
        {

        }

        public virtual void OnInput()
        {

        }
    }
}
