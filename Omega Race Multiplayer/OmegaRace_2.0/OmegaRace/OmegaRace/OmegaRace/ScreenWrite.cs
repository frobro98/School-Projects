using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpriteAnimation;

namespace OmegaRace
{
    class ScreenWrite
    {
        private SpriteBatch textBatch;
        private Sprite_Proxy mainMenu;
        private SpriteFont menuFont;
        private GraphicsDevice graphicsDev;

        private static ScreenWrite swInstance = null;

        private ScreenWrite(GraphicsDevice graphicsDev)
        {
            this.graphicsDev = graphicsDev;
            textBatch = new SpriteBatch(graphicsDev);
            menuFont = Game1.GameInstance.Content.Load<SpriteFont>("SpriteFont1");
            mainMenu = Game1.GameInstance.MenuProxy;
        }

        public static void drawMenuScreen()
        {
            string message = "Create Session (Press A)\n" +
                             "Join Session   (Press B)";

            Instance.textBatch.Begin();
            Instance.textBatch.DrawString(Instance.menuFont, message, new Vector2(161, 161), Color.Black);
            Instance.textBatch.DrawString(Instance.menuFont, message, new Vector2(161, 161), Color.White);
            Instance.textBatch.End();
        }

        public static void drawMainMenu()
        {
            Instance.textBatch.Begin();
            Instance.mainMenu.Draw(Instance.textBatch);
            Instance.textBatch.End();
        }

        public static void drawMessage(string mess)
        {
            Instance.graphicsDev.Clear(Color.CornflowerBlue);

            Instance.textBatch.Begin();
            Instance.textBatch.DrawString(Instance.menuFont, mess, new Vector2(161, 161), Color.Black);
            Instance.textBatch.DrawString(Instance.menuFont, mess, new Vector2(160, 160), Color.White);
            Instance.textBatch.End();
        }

        public static void gameOverScreen()
        {
            Instance.graphicsDev.Clear(Color.Navy);

            Instance.textBatch.Begin();

            Instance.textBatch.DrawString(Instance.menuFont, "Game", new Vector2(350, 200), Color.White);
            Instance.textBatch.DrawString(Instance.menuFont, "Over", new Vector2(350, 225), Color.White);

            Instance.textBatch.DrawString(Instance.menuFont, "Press A to play again", new Vector2(150, 380), Color.White);
            Instance.textBatch.DrawString(Instance.menuFont, "Press B to quit" , new Vector2(450, 380), Color.White);

            Instance.textBatch.End();
        }

        private static ScreenWrite Instance
        {
            get
            {
                if (swInstance == null)
                {
                    swInstance = new ScreenWrite(Game1.GameInstance.GraphicsDevice);
                }

                return swInstance;
            }
        }
    }
}
