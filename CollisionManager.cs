using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdatedEngine2
{
    class CollisionManager
    {
        // Lister passes in from Kernel
        public void Manager(List<IEntity> pLister)
        {
            for (int i = 0; i < pLister.Count() - 1; i++)
            {
                for (int j = i + 1; j < pLister.Count(); j++)
                {
                    if (CheckCollision(pLister[i], pLister[j]))
                    {
                        // Call OnCollide for each colliding entity
                        pLister[i].OnCollide(pLister[j]);

                        pLister[j].OnCollide(pLister[i]);
                    }
                }
            }
        }

        public bool CheckCollision(IEntity entity1, IEntity entity2)
        {
            // Check entity hitboxes to see if they overlap
            if (((GameEntity)entity1).HitBox.Intersects(((GameEntity)entity2).HitBox))
            {
                // If yes, return true
                return true;
            }
            else return false;
        }
    }
}
