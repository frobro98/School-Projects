using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Movement : Command
    {
        private GridNode gridRoot;
        private GameObject.Name name;
        private Index index;

        public Movement()
        {
            this.gridRoot = (GridNode)GameObjectManager.find(GameObject.Name.Grid);
            this.name = (GameObject.Name)gridRoot.getName();
            this.index = gridRoot.getIndex();
        }

        public void set(GridNode gridNode, GameObject.Name name, Index index = Index.Index_Null)
        {
            this.gridRoot = gridNode;
            this.name = name;
            this.index = index;
        }

        public override void execute(float time)
        {
            gridRoot.process();
            TimeEventManager.add(GameManager.MoveFrameTime, this, TimeEvent.EventType.Movement);
            SoundManager.playMovement();
        }
    }
}
