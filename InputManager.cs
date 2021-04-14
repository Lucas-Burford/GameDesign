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
    class InputManager
    {
        // Update method that is called every frame to check for changes
        public void Update(List<IEntity> lister) 
        {
            // For loop for finding out which entity needs to update input
            for (int i = 0; i < lister.Count(); i++)
            {
                // IF current iteratation of loop is checking Player, call OnInput in Player
                if (lister[i] is Player) 
                {
                    // Casting entityList iteration to IInput then calling  OnInput on that entity (only checking for Player for now)
                    ((IInput)lister[i]).OnInput();
                }
            }
        }
    }
}
