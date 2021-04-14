using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace UpdatedEngine2
{
    /// <summary>
    /// Class for handling the animation of sprites
    /// Following the guide of RB Whitaker, available at http://rbwhitaker.wikidot.com/monogame-texture-atlases-2
    /// Animation doesn't work effectively with my sprite sheets, but I want to leave the code in as proof of concept, below is a video of it 'working'
    /// https://youtu.be/QXHD39PcQ-U
    /// </summary>
    class AnimatedSprite
    {
        #region Members
        // Create a Texture2D to store texture atlas
        public Texture2D Texture { get; set; }

        // Number of rows in the texture atlas
        public int Rows { get; set; }

        // Number of columns in the texture atlas
        public int Columns { get; set; }

        // Current frame the animation is on
        private int currentFrame;

        // Total frames in the animation
        private int totalFrames;
        #endregion

        /// <summary>
        /// Constructor for AnimatedSprite
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="rows"></param>
        /// <param name="comuns"></param>
        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        /// <summary>
        /// Update animation, step through frames
        /// </summary>
        public void Update()
        {
            currentFrame++;

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        /// <summary>
        /// Draw animation to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="location"></param>
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
