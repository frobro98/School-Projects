using System;

namespace SpaceInvaders
{
    class PlayerDeath : Observer
    {

        public override void notify()
        {
            DeadPlayer dead;
            if (subj.GameObj1 is PlayerShip)
            {
                dead  = PlayerFactory.create(DeadPlayer.Dead.Dead, subj.GameObj1.getX(), subj.GameObj1.getY());
                DestroyManager.attach(subj.GameObj1);
            }
            else
            {
                dead = PlayerFactory.create(DeadPlayer.Dead.Dead, subj.GameObj2.getX(), subj.GameObj2.getY());
                DestroyManager.attach(subj.GameObj2);
            }

            TimeEventManager.stopUpdate();
            
            
            TimeEventManager.add(3f, new PlayerReset(dead));

            //AnimatedSprite playDeath = new AnimatedSprite(SpriteEnum.PlayerExplosion, ImageEnum.PlayerExplosion_2);
            //TimeEventManager.add(1f, playDeath);

        }
    }
}
