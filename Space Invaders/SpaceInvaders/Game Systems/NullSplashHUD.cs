using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class NullSplashHUD : HUDStrategy
    {
        public NullSplashHUD()
            : base(new ProxySprite(SpriteEnum.Null, Index.Index_Null, 0f, 0f))
        {
        }
    }
}
