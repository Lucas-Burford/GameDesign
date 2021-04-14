using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace UpdatedEngine2
{
    /// <summary>
    /// Class for a Player object
    /// </summary>
    class Player : GameEntity
    {
        // Enum for selected gender
        public enum Gender
        {
            Male,
            Female
        }
        public Gender gender;

        private KeyboardState keyboardState;

        private float moveSpeed;

        private Vector2 pos;
        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        int number = 5;
        int number2 = 10;

        // Create a List of type IEntity to store items the player picks up
        private List<IEntity> playerInventory = new List<IEntity>();

        Rectangle _hitBox;

        public Player()
        {
            moveSpeed = 5;

            pos = new Vector2(315, 350);

            Console.WriteLine(number + number2);
        }

        /// <summary>
        /// Update player state
        /// </summary>
        public override void Update()
        {
            // Capture keyboard state every frame 
            keyboardState = Keyboard.GetState();

            _hitBox.Location = new Point((int)pos.X, (int)pos.Y);

            //Console.WriteLine("X: " + HitBox.X);
            //Console.WriteLine("Y: " + HitBox.Y);

            CheckWalls();
        }

        /// <summary>
        /// Handle collisions with entities
        /// </summary>
        /// <param name="entityCol"></param>
        public override void OnCollide(IEntity entityCol)
        {
            if (entityCol is Artefact)
            {
                Console.WriteLine("Hit");
                AddToInventory(entityCol);
            }

            if (entityCol is Token)
            {
                AddToInventory(entityCol);
            }
        }

        // Method for handling input
        public override void OnInput()
        {
            if (keyboardState.IsKeyDown(Keys.W))
            {
                pos.Y -= moveSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                pos.Y += moveSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                pos.X -= moveSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                pos.X += moveSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                Jump();
            }
        }

        private void Jump()
        {
            pos.Y -= 10;
        }

        /// <summary>
        /// Keep player in bounds of the level
        /// </summary>
        private void CheckWalls()
        {
            // Do walls
            if (pos.X <= 0)
            {
                pos.X += moveSpeed;
            }

            if (pos.X >= 550)
            {
                pos.X -= moveSpeed;
            }

            if (pos.Y <= -10)
            {
                pos.Y += moveSpeed;
            }

            if (pos.Y >= 550)
            {
                pos.Y -= moveSpeed;
            }
        }

        /// <summary>
        /// Add passed in entity to player's inventory
        /// </summary>
        /// <param name="entity"></param>
        public void AddToInventory(IEntity entity)
        {
            // Add the passed through item to the player's inventory
            playerInventory.Add(entity);
        }
    }
}
