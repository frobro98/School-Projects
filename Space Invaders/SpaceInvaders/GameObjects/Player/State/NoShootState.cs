using System;

namespace SpaceInvaders
{
    class NoShootState : PlayerState
    {
        public override float moveLeft()
        {
            return 5f;
        }

        public override float moveRight()
        {
            return 5f;
        }

        public override void shootMissile(PlayerShip player, float x, float y)
        {
            
        }

        public override void handle(Context context)
        {
            PlayerShip player = (PlayerShip)context;
            player.changeState(PlayerShip.PlayerStates.Ready);
        }
    }
}
