using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionManager;

namespace OmegaRace
{


    class GameObjNode : ManLink
    {
        public GameObject gameObj;
        public GameObjType type;

        public GameObjNode()
        {
            this.Initialize();
            this.gameObj = null;
        }

        public void Set(GameObject _obj)
        {
            base.Initialize();

            this.gameObj = _obj;
            this.type = _obj.type;
        }

        public override Enum getName()
        {
            return type;
        }
    }
}
