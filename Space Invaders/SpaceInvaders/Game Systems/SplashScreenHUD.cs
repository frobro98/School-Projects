using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SplashScreenHUD : HUDStrategy
    {
        public SplashScreenHUD()
            : base(new ProxySprite(SpriteEnum.Splash, Index.Index_Null, 512f, 448f))
        {
        }
    }
}
