using System;

namespace SpaceInvaders
{
    class ReadyState : PlayerState
    {
        public override float moveLeft()
        {
            return 7f;
        }

        public override float moveRight()
        {
            return 7f;
        }

        public override void shootMissile(PlayerShip player, float x, float y)
        {
            MissileFactory.create(Missile.MissileName.Missile, x, y, player);
            SoundManager.playMissile();
            player.request();
        }

        public override void handle(Context context)
        {
            PlayerShip player = (PlayerShip)context;
            player.changeState(PlayerShip.PlayerStates.NoShoot);
        }
    }
}
