using System;

namespace SpaceInvaders
{
    class StartState : PlayerState
    {
        public override float moveLeft()
        {
            return 0f;
        }

        public override float moveRight()
        {
            return 0f;
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
