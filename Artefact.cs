using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UpdatedEngine2
{
    class Artefact : GameEntity
    {
        // Create a bool to check if the artefact has been collected, call it isCollected and default to false
        public bool isCollected = false;

        public Vector2 pos;



        public Artefact()
        {

        }

        public override void Update()
        {

        }

        public override void OnCollide(IEntity entityCol)
        {
            //isCollected = true;
        }

        public void SetPos(int x, int y)
        {
            pos = new Vector2(x, y);
        }
    }
}
