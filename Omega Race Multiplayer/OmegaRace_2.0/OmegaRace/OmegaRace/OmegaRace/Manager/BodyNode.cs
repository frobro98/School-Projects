using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Box2D.XNA;

namespace OmegaRace
{
    class BodyNode
    {
        public Body body;

        public BodyNode next;
        public BodyNode prev;

        public BodyNode(Body _body)
        {
            this.next = null;
            this.prev = null;
            this.body = _body;
        }

        public void Set(Body _body)
        {
            this.next = null;
            this.prev = null;
            this.body = _body;
        }
        
    }
}
