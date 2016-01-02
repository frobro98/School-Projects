using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;

namespace OmegaRace
{
    class SpriteNode
    {
        public DisplayObject sprite;

        public SpriteNode next;
        public SpriteNode prev;

        public SpriteNode(DisplayObject _sprite)
        {
            sprite = _sprite;
        }

        protected virtual void Initialize()
        {
            this.next = null;
            this.prev = null;
        }
    }
}
