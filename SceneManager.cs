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
    class SceneManager
    {
        public List<IEntity> entityList = new List<IEntity>();

        public void StoreEntity(IEntity Ientity)
        {
            // Add entity to list called entityList
            entityList.Add(Ientity);
        }

        public List<IEntity> List()
        {
            // Return entityList to caller
            return entityList;
        }

        public void Update()
        {
            // Update entities in entityList
            for (int i = 0; i < entityList.Count; i++)
            {
                entityList[i].Update();
            }
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            // Call Draw for each entity in entityList so they are all drawn on screen
            for (int i = 0; i < entityList.Count; i++)
            {
                entityList[i].Draw(pSpriteBatch);
            }
        }
    }
}
