using System;

namespace SpaceInvaders
{
    class RemoveSplat : Command
    {
        private ProxySprite proxy;

        public RemoveSplat(ProxySprite p)
        {
            proxy = p;
        }

        public override void execute(float time)
        {
            BatchGroup group = SpriteBatchManager.find(BatchGroup.BatchType.Explosions);
            group.detach(proxy);
        }
    }
}
