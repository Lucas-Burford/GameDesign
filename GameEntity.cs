using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UpdatedEngine2
{
    public abstract class GameEntity : Entity // Replaces PongEntity from previous version
    {
        private Texture2D mTexture;
        private Vector2 position;
        private Rectangle hitBox;
        private Rectangle wallBox;

        public new Texture2D Texture
        {
            get { return mTexture; }
            set { mTexture = value; }
        }

        public new Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);
        }

        public virtual new Rectangle HitBox
        {
            // Create rectangle at entity position using its width and height
            get { hitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); return hitBox; }
            set { hitBox.Location = new Point((int)position.X, (int)position.Y); }
        }

        public virtual Rectangle WallhitBox
        {
            get { wallBox = new Rectangle(); return wallBox; }
        }

        public override void OnCollide(IEntity entityCol)
        {

        }

        public override void OnInput()
        {

        }
    }
}
