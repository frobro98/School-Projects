using System;

namespace SpaceInvaders
{
    class GameHUD
    {
        private HUDStrategy type;
        private Azul.SpriteFont score1;
        private Azul.SpriteFont p1Score;
        private Azul.SpriteFont score2;
        private Azul.SpriteFont p2Score;
        private Azul.SpriteFont credit;
        private Azul.SpriteFont numCredits;

        private ProxySprite[] hudLives;
        private HUDStrategy[] hudTypes;

        private Azul.SpriteFont hiScoreHeader;
        private Azul.SpriteFont hiScore;

        public GameHUD()
        {
            const float scoreY = Constants.SCREEN_HEIGHT - 20f;

            score1 = new Azul.SpriteFont("SCORE<1>", Azul.AZUL_FONTS.Consolas36pt, Constants.SCREEN_WIDTH * .05f, scoreY);
            score2 = new Azul.SpriteFont("SCORE<2>", Azul.AZUL_FONTS.Consolas36pt, Constants.SCREEN_WIDTH * .83f, scoreY);
            hiScoreHeader = new Azul.SpriteFont("HI-SCORE", Azul.AZUL_FONTS.Consolas36pt, Constants.SCREEN_WIDTH * .45f, scoreY);
            p1Score = new Azul.SpriteFont("0000", Azul.AZUL_FONTS.Consolas36pt, Constants.SCREEN_WIDTH * .08f, scoreY - 40f);
            p2Score = new Azul.SpriteFont("0000", Azul.AZUL_FONTS.Consolas36pt, Constants.SCREEN_WIDTH * .87f, scoreY - 40f);
            hiScore = new Azul.SpriteFont("0000", Azul.AZUL_FONTS.Consolas36pt, Constants.SCREEN_WIDTH * .48f, scoreY - 40f);
            credit = new Azul.SpriteFont("Credit", Azul.AZUL_FONTS.Consolas36pt, Constants.SCREEN_WIDTH * .7f, 45);
            numCredits = new Azul.SpriteFont("0", Azul.AZUL_FONTS.Consolas36pt, Constants.SCREEN_WIDTH * .9f, 45);

            hudLives = new ProxySprite[3]{new ProxySprite(SpriteEnum.Player, Index.Index_Null, 75, 50), new ProxySprite(SpriteEnum.Player, Index.Index_Null, 150, 50),
                                          new ProxySprite(SpriteEnum.Player, Index.Index_Null, 225, 50)};
            hudLives[0].Color = new Azul.Color(0f, 1f, 0f);
            hudLives[1].Color = new Azul.Color(0f, 1f, 0f);
            hudLives[2].Color = new Azul.Color(0f, 1f, 0f);

            hudTypes = new HUDStrategy[2] { new SplashScreenHUD(), new NullSplashHUD() };
        }

        public void setSplashScreen()
        {
            type = hudTypes[0];
        }

        public void setGameScreen()
        {
            type = hudTypes[1];
        }

        public void update()
        {
            if (PlayerManager.getPlayer1() != null)
            {
                p1Score.Update(PlayerManager.getPlayer1().Score.ToString("0000"));
            }
            if (PlayerManager.getPlayer2() != null)
            {
                p2Score.Update(PlayerManager.getPlayer2().Score.ToString("0000"));
            }

            hiScore.Update(ScoreManager.HiScore.ToString("0000"));

        }

        public void draw()
        {
            score1.Draw();
            score2.Draw();
            hiScoreHeader.Draw();
            p1Score.Draw();
            p2Score.Draw();
            hiScore.Draw();

            credit.Draw();
            numCredits.Draw();

            type.draw();

            if (PlayerManager.getCurrentPlayer() != null)
            {
                for (int i = 0; i < PlayerManager.getCurrentPlayer().Lives; i++)
                {
                    hudLives[i].update();
                    hudLives[i].draw();
                }
            }
        }
    }
}
