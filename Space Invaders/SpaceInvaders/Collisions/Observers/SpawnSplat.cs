using System;

namespace SpaceInvaders
{
    class SpawnSplat : Observer
    {
        public override void notify()
        {
            ProxySprite prox;
            if (subj.GameObj1 is Alien)
            {
                prox = new ProxySprite(SpriteEnum.Splat, Index.Index_Null, subj.GameObj1.getX(), subj.GameObj1.getY());
            }
            else
            {
                prox = new ProxySprite(SpriteEnum.Splat, Index.Index_Null, subj.GameObj2.getX(), subj.GameObj2.getY());
            }
            SpriteBatchManager.attachToGroup(prox, BatchGroup.BatchType.Explosions);
            TimeEventManager.add(.5f, new RemoveSplat(prox));

        }
    }
}
