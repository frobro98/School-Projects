using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class NullSprite : GameSprite
    {
        public NullSprite(SpriteEnum name = SpriteEnum.Null, Index index = Index.Index_Null)
            : base(name, index)
        {

        }

        public override void draw()
        {
            
        }

    }
}
