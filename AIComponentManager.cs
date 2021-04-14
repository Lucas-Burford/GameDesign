using System;
using System.Collections.Generic;
using System.Text;

namespace UpdatedEngine2
{
    class AIComponentManager
    {
        AIComponent _AIComponent = new AIComponent();

        public void Update()
        {
            _AIComponent.Update();
        }
    }
}
