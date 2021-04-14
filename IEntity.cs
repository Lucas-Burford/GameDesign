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
    public interface IEntity
    {
        void Texture();

        void Position();

        void Update();

        void Draw(SpriteBatch spriteBatch);

        void OnCollide(IEntity entitycol);
    }
}
