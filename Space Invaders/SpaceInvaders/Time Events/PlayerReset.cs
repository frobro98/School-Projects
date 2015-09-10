using System;

namespace SpaceInvaders
{
    class PlayerReset : Command
    {
        private DeadPlayer dp;

        public PlayerReset(DeadPlayer dead)
        {
            dp = dead;
        }

        public override void execute(float time)
        {
            DestroyManager.attach(dp);
            GameManager.playerDeath();
            TimeEventManager.remove(this);
            TimeEventManager.startUpdate(time);
            PlayerFactory.create(PlayerShip.PlayerName.Player);
        }
    }
}
