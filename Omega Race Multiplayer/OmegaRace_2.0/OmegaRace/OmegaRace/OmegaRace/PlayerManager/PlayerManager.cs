using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionManager;
using Box2D.XNA;
using SpriteAnimation;
using Microsoft.Xna.Framework;

namespace OmegaRace
{
    class PlayerManager
    {

        private static PlayerManager instance;

        private Player p1;
        private Player p2;

        private PlayerManager()
        {
            createPlayers();
        }

        public static PlayerManager Instance()
        {
            if (instance == null)
                instance = new PlayerManager();
            return instance;
        }

        public void createPlayers()
        {
            p1 = new Player(PlayerID.one);
            p2 = new Player(PlayerID.two);
        }

        public Player getPlayer(PlayerID _id)
        {
            if (_id == PlayerID.one)
                return p1;
            else
                return p2;
        }


        public void clear()
        {
            instance = null;
        }

        public void respawn(object obj)
        {

            CallBackData data = (CallBackData)obj;

            Player player = getPlayer(data.playerID);

            if (!player.Alive())
            {

                player.lives--;

                switch (player.lives)
                {

                    case 3:
                        {
                            SBNode sbNode = SpriteBatchManager.Instance().getBatch(batchEnum.ships);
                            sbNode.removeDisplayObject(player.lifeSprite3);

                            respawnData(data.playerID);
                            player.state = PlayerState.alive;

                            break;
                        }

                    case 2:
                        {
                            SBNode sbNode = SpriteBatchManager.Instance().getBatch(batchEnum.ships);
                            sbNode.removeDisplayObject(player.lifeSprite2);

                            respawnData(data.playerID);
                            player.state = PlayerState.alive;

                            break;
                        }

                    case 1:
                        {
                            SBNode sbNode = SpriteBatchManager.Instance().getBatch(batchEnum.ships);
                            sbNode.removeDisplayObject(player.lifeSprite1);

                            respawnData(data.playerID);
                            player.state = PlayerState.alive;

                            break;
                        }


                    case 0:
                        {
                            if (player.id == PlayerID.one)
                            {
                                ScoreManager.Instance().p2Win();
                            }
                            else
                            {
                                ScoreManager.Instance().p1Win();
                            }

                            Game1.GameInstance.GameOver();
                            break;
                        }
                }
                player.state = PlayerState.alive;
            }
        }

        private void respawnData(PlayerID _id)
        {

            switch (_id)
            {
                case PlayerID.one:
                    {
                    Ship p2Ship = PlayerManager.Instance().getPlayer(PlayerID.two).playerShip;

                    if(p2Ship.spriteRef.pos.Y < 95)
                        Data.Instance().createShip1(new Vector2(150, 130), (float)(90.0f * (Math.PI / 180.0f))); 
                    else
                        Data.Instance().createShip1(new Vector2(150, 60), -(float)(90.0f * (Math.PI / 180.0f))); 
                    break;
                    }
                case PlayerID.two:
                    Ship p1Ship = PlayerManager.Instance().getPlayer(PlayerID.one).playerShip;

                    if(p1Ship.spriteRef.pos.Y > 95)
                        Data.Instance().createShip2(new Vector2(150, 60), -(float)(90.0f * (Math.PI / 180.0f))); 
                    else
                        Data.Instance().createShip2(new Vector2(150, 130), (float)(90.0f * (Math.PI / 180.0f))); 
                    break;
            }
        }
    }
}
