using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OmegaRace;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace NetworkedOmegaRace
{
    public class NetworkController
    {
        private NetworkSession netSession;
        private KeyboardState oldState;
        private GamePadState oldPadState;
        private const int maxNumPlayers = 2;
        private bool isNetworked;
        private bool isHost;

        public NetworkController()
        {
            netSession = null;
            isNetworked = false;
            isHost = false;
        }

        public void Update()
        {

            if (netSession == null)
            {
                ShowStartScreen();
            }
            else if(isNetworked)
            {
                netSession.Update();
            }
        }

        private void ShowStartScreen()
        {


            KeyboardState currKeyState = Keyboard.GetState();
            GamePadState currPadState = GamePad.GetState(PlayerIndex.One);
            if (Game1.state == gameState.mainmenu)
            {
                if ((currKeyState.IsKeyDown(Keys.A) && !oldState.IsKeyDown(Keys.A))|| 
                    (currPadState.IsButtonDown(Buttons.A) && !oldPadState.IsButtonDown(Buttons.A)))
                {
                    Game1.state = gameState.lobby;
                }
            }
            else if (Game1.state == gameState.winner)
            {
                if ((currKeyState.IsKeyDown(Keys.A) && !oldState.IsKeyDown(Keys.A)) || 
                    (currPadState.IsButtonDown(Buttons.A) && !oldPadState.IsButtonDown(Buttons.A)))
                {
                    Game1.state = gameState.lobby;
                    oldState = currKeyState;
                    oldPadState = currPadState;
                    return;
                }
                else if ((currKeyState.IsKeyDown(Keys.B) && !oldState.IsKeyDown(Keys.B)) || 
                        (currPadState.IsButtonDown(Buttons.B) && !oldPadState.IsButtonDown(Buttons.B)))
                {
                    Game1.GameInstance.Exit();
                }
            }
            if (Game1.state == gameState.lobby && Game1.GameInstance.IsActive)
            {
                if (Gamer.SignedInGamers.Count == 0)
                {
                    Guide.ShowSignIn(maxNumPlayers, false);
                }
                else if ((currKeyState.IsKeyDown(Keys.A) && !oldState.IsKeyDown(Keys.A)) ||
                    (currPadState.IsButtonDown(Buttons.A) && !oldPadState.IsButtonDown(Buttons.A)))
                {
                    CreateSession();
                }
                else if ((currKeyState.IsKeyDown(Keys.B) && !oldState.IsKeyDown(Keys.B)) ||
                        (currPadState.IsButtonDown(Buttons.B) && !oldPadState.IsButtonDown(Buttons.B)))
                {
                    JoinSession();
                }
            }

            oldPadState = currPadState;
            oldState = currKeyState;
        }

        private void CreateSession()
        {
            netSession = NetworkSession.Create(NetworkSessionType.SystemLink, maxNumPlayers, maxNumPlayers);
            isHost = true;
            isNetworked = true;
            Game1.state = gameState.game;
        }

        private void JoinSession()
        {
            ScreenWrite.drawMessage("Joining session...");
            try
            {
                using (AvailableNetworkSessionCollection availableSess = NetworkSession.Find(NetworkSessionType.SystemLink, maxNumPlayers, null))
                {
                    if (availableSess.Count == 0)
                    {
                        ScreenWrite.drawMessage("No network seesions found.");
                    }

                    netSession = NetworkSession.Join(availableSess[0]);
                }
            }
            catch (Exception e)
            {
                ScreenWrite.drawMessage(e.Message);
            }
           
            isHost = false;
            isNetworked = true;
            Game1.state = gameState.game;
        }

        public NetworkSession Session
        {
            get
            {
                return netSession;
            }

            set
            {
                netSession = value;
            }
        }
        public bool IsNetworked
        {
            get
            {
                return isNetworked;
            }
        }
    }
}
