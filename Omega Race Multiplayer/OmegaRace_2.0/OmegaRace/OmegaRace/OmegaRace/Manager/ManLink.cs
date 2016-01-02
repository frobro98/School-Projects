using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;

namespace OmegaRace
{
    abstract class ManLink
    {
        public ManLink next;
        public ManLink prev;

        public ManLink()
        {
            
        }

        protected virtual void Initialize()
        {
            this.next = null;
            this.prev = null;
        }

        abstract public Enum getName();

    }
}
