using System;

namespace SpaceInvaders
{
    class SpawnExplosion : Observer
    {
        public override void notify()
        {
            if (subj.GameObj1 is TopWall || subj.GameObj1 is BottomWall)
            {
                ProxySprite p = new ProxySprite(SpriteEnum.Explosion, Index.Index_Null, subj.GameObj2.getX(), subj.GameObj2.getY());
                SpriteBatchManager.attachToGroup(p, BatchGroup.BatchType.Explosions);
                TimeEventManager.add(1f, new RemoveExplosion(p));
            }
            else if (subj.GameObj2 is TopWall || subj.GameObj2 is BottomWall)
            {
                ProxySprite p = new ProxySprite(SpriteEnum.Explosion, Index.Index_Null, subj.GameObj1.getX(), subj.GameObj1.getY());
                SpriteBatchManager.attachToGroup(p, BatchGroup.BatchType.Explosions);
                TimeEventManager.add(1f, new RemoveExplosion(p));
            }
            else
            {
                ProxySprite p = new ProxySprite(SpriteEnum.Explosion, Index.Index_Null, subj.GameObj1.getX(), subj.GameObj1.getY());
                SpriteBatchManager.attachToGroup(p, BatchGroup.BatchType.Explosions);
                TimeEventManager.add(1f, new RemoveExplosion(p));
            }
        }
    }
}
