using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace UpdatedEngine2
{
    class EntityManager
    {
        // Create player object
        public IEntity CreatePlayer() // Replaces old CreatePaddle, as the player is now controlling a character (a player) not a paddle
        {
            return new Player();
        }

        public IEntity CreateArtefact() // Replaces old CreateBall() 
        {
            return new Artefact();
        }

        public IEntity CreateToken() // New object added with my game
        {
            return new Token();
        }
    }
}
