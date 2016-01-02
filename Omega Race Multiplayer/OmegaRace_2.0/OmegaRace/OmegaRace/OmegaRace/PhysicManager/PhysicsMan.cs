using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Box2D.XNA;
using CollisionManager;

namespace OmegaRace
{
    class PhysicsMan : Manager
    {
        private static PhysicsMan instance;

        private PhysicsMan()
        {

        }

        public static PhysicsMan Instance()
        {
            if (instance == null)
                instance = new PhysicsMan();
            return instance;
        }

        public void addPhysicsObj(GameObject _gameObj,Body _body)
        {
            PhysicsObj obj = new PhysicsObj(_gameObj, _body);
            _gameObj.physicsObj = obj;

            this.privActiveAddToFront((ManLink)obj, ref this.active);
        }

        public void clear()
        {
            this.active = null;
            instance = null;
        }

        public void Update()
        {
            ManLink ptr = this.active;
            PhysicsObj physNode = null;
            Body body = null;


            while (ptr != null)
            {
                physNode = (PhysicsObj)ptr;
                body = physNode.body;

                physNode.gameObj.pushPhysics(body.GetAngle(), body.Position, physNode.gameObj.type);

                ptr = ptr.next;
            }

        }

        public void removePhysicsObj(PhysicsObj _obj)
        {
            this.privActiveRemoveNode((ManLink)_obj, ref this.active);

        }

        protected override object privGetNewObj()
        {
            throw new NotImplementedException();
        }

    }
}
