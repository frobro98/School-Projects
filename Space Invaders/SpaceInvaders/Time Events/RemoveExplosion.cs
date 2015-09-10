using System;

namespace SpaceInvaders
{
    class RemoveExplosion : Command
    {
        private ProxySprite spr;

        public RemoveExplosion(ProxySprite s)
        {
            spr = s;
        }

        public override void execute(float time)
        {
            BatchGroup b = spr.getBatch();
            b.detach(spr);
        }
    }
}
