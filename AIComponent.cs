using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UpdatedEngine2
{
    class AIComponent : GameEntity
    {
        private float moveSpeed;

        private Vector2 pos;
        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }


        public AIComponent()
        {
           // moveSpeed = 1;
        }

        public override void Update()
        {
            pos.X += moveSpeed;
            CheckWalls();
        }

        private void CheckWalls()
        {
            if (pos.X <= -10 || pos.X >= 550)
            {
                moveSpeed *= -1;
            }
        }

        public void SetPos(int x, int y)
        {
            pos = new Vector2(x, y);
        }
    }
}
