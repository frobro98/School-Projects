using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;

namespace OmegaRace
{
    abstract class ContainerLink
    {
        public ContainerLink next;
        public ContainerLink prev;

        public ContainerLink()
        {
            this.Initialize();
        }
        protected void Initialize()
        {
            this.next = null;
            this.prev = null;
        }
        abstract public Enum getName();
    }
}
