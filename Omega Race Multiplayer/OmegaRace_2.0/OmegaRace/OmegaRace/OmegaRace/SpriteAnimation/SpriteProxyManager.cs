using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework;
using OmegaRace;

namespace CollisionManager
{

    
    enum ProxyType
    {
        ship,
        missile,
        bomb,
        boxs
    }

    class SpriteProxyManager : Manager
    {
        private static SpriteProxyManager instance;


        private SpriteProxyManager()
        {

        }

        public static SpriteProxyManager Instance()
        {
            if (instance == null)
                instance = new SpriteProxyManager();
            return instance;
        }

        public void clear()
        {
            this.active = null;
            instance = null;
        }

        protected override object privGetNewObj()
        {
            throw new NotImplementedException();
        }
        
    }
}
