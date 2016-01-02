using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;

using CollisionManager;

namespace OmegaRace
{
    class InputManager
    {
        private Queue<InputHdr> hdrQueue;
        private KeyboardState keyboardState;
        private KeyboardState oldKeyState;
        private GamePadState player1Pad;
        private GamePadState player2Pad;
        private GamePadState oldP1State;
        private GamePadState oldP2State;
        Player player1;
        Player player2;

        const int shipSpeed = 200;
        private static InputManager imInstance = null;

        private InputManager()
        {
            hdrQueue = new Queue<InputHdr>();
            player1 = PlayerManager.Instance().getPlayer(PlayerID.one);
            player2 = PlayerManager.Instance().getPlayer(PlayerID.two);
        }

        // Used to push a new input to manager
        public static void pushInput(ref InputHdr hdr)
        {
            Instance.hdrQueue.Enqueue(hdr);
        }

        public static void process()
        {
            while (Instance.hdrQueue.Count != 0)
            {
                InputHdr hdr = Instance.hdrQueue.Dequeue();

                Instance.processInput(ref hdr);

            }
        }

        private void processInput(ref InputHdr hdr)
        {
            Player p = PlayerManager.Instance().getPlayer(hdr.player);
            Ship ship = p.playerShip;
            PhysicsObj pObj = ship.physicsObj;
            
            switch (hdr.input)
            {
                case InputType.Forward:
                    Vector2 direction = new Vector2((float)(Math.Cos(pObj.body.GetAngle())), (float)(Math.Sin(pObj.body.GetAngle())));
                    direction.Normalize();
                    direction *= shipSpeed;
                    pObj.body.ApplyLinearImpulse(direction, pObj.body.GetWorldCenter());
                    break;
                case InputType.RotateLeft:
                    pObj.body.Rotation -= 0.1f;
                    break;
                case InputType.RotateRight:
                    pObj.body.Rotation += 0.1f;
                    break;
                case InputType.FireMissile:
                    p.createMissile();
                    break;
                case InputType.DropBomb:
                    if (p.state == PlayerState.alive)
                    {
                        GameObjManager.Instance().createBomb(hdr.player);
                    }
                    break;
                case InputType.Collision:
                    ColHdr cHdr = (ColHdr)hdr.colInfo;
                    GameObject go1 = GameObjManager.Instance().findFromIndex(cHdr.goID1);
                    GameObject go2 = GameObjManager.Instance().findFromIndex(cHdr.goID2);
                    if (go1 != null && go2 != null)
                    {
                        go1.Accept(go2, cHdr.pos);
                    }
                    break;
                default:
                    break;
            }
        }

        public static void updateInputs()
        {

            if (Game1.Network.IsNetworked)
            {
                Instance.NetworkInputUpdate();
            }
            else
            {
                Instance.LocalInputUpdate();
            }
            

        }

        private void LocalInputUpdate()
        {
            Instance.keyboardState = Keyboard.GetState();
            Instance.player1Pad = GamePad.GetState(PlayerIndex.One);
            Instance.player2Pad = GamePad.GetState(PlayerIndex.Two);

            InputHdr iHdr;
            iHdr.colInfo = null;
            iHdr.input = InputType.NotInitialied;
            iHdr.player = PlayerID.none;

            if (Instance.oldKeyState.IsKeyDown(Keys.D) || Instance.oldP1State.IsButtonDown(Buttons.DPadRight))
            {
                iHdr.input = InputType.RotateRight;
                iHdr.player = PlayerID.one;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }

            if (Instance.oldKeyState.IsKeyDown(Keys.A) || Instance.oldP1State.IsButtonDown(Buttons.DPadLeft))
            {
                iHdr.input = InputType.RotateLeft;
                iHdr.player = PlayerID.one;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }

            if (Instance.oldKeyState.IsKeyDown(Keys.W) || Instance.oldP1State.IsButtonDown(Buttons.DPadUp))
            {
                iHdr.input = InputType.Forward;
                iHdr.player = PlayerID.one;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }

            if ((Instance.oldKeyState.IsKeyDown(Keys.X) && Instance.keyboardState.IsKeyUp(Keys.X)))
            {
                iHdr.input = InputType.FireMissile;
                iHdr.player = PlayerID.one;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }
            else if ((Instance.oldP1State.IsButtonDown(Buttons.A) && Instance.player1Pad.IsButtonUp(Buttons.A)))
            {
                iHdr.input = InputType.FireMissile;
                iHdr.player = PlayerID.one;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }

            if (Instance.oldKeyState.IsKeyDown(Keys.C) && Instance.keyboardState.IsKeyUp(Keys.C))
            {
                iHdr.input = InputType.DropBomb;
                iHdr.player = PlayerID.one;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }
            else if (Instance.oldP1State.IsButtonDown(Buttons.B) && Instance.player1Pad.IsButtonUp(Buttons.B))
            {
                iHdr.input = InputType.DropBomb;
                iHdr.player = PlayerID.one;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }


            if (Instance.oldKeyState.IsKeyDown(Keys.Right) || Instance.oldP2State.IsButtonDown(Buttons.DPadRight))
            {
                iHdr.input = InputType.RotateRight;
                iHdr.player = PlayerID.two;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }

            if (Instance.oldKeyState.IsKeyDown(Keys.Left) || Instance.oldP2State.IsButtonDown(Buttons.DPadLeft))
            {
                iHdr.input = InputType.RotateLeft;
                iHdr.player = PlayerID.two;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }


            if (Instance.oldKeyState.IsKeyDown(Keys.Up) || Instance.oldP2State.IsButtonDown(Buttons.DPadUp))
            {
                iHdr.input = InputType.Forward;
                iHdr.player = PlayerID.two;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }

            if ((Instance.oldKeyState.IsKeyDown(Keys.OemQuestion) && Instance.keyboardState.IsKeyUp(Keys.OemQuestion)) || (Instance.oldP2State.IsButtonDown(Buttons.A) && Instance.player2Pad.IsButtonUp(Buttons.A)))
            {
                iHdr.input = InputType.FireMissile;
                iHdr.player = PlayerID.two;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }

            if (Instance.oldKeyState.IsKeyDown(Keys.OemPeriod) && Instance.keyboardState.IsKeyUp(Keys.OemPeriod) || (Instance.oldP2State.IsButtonDown(Buttons.B) && Instance.player2Pad.IsButtonUp(Buttons.B)))
            {
                iHdr.input = InputType.DropBomb;
                iHdr.player = PlayerID.two;
                iHdr.networked = false;
                iHdr.colInfo = null;
                OutputQueue.pushHeader(iHdr);
            }
            

            Instance.oldKeyState = Instance.keyboardState;
            Instance.oldP1State = Instance.player1Pad;
            Instance.oldP2State = Instance.player2Pad;
        }

        void NetworkInputUpdate()
        {
            foreach (LocalNetworkGamer gamer in Game1.Network.Session.LocalGamers)
            {

                Instance.keyboardState = Keyboard.GetState();
                Instance.player1Pad = GamePad.GetState(gamer.SignedInGamer.PlayerIndex);

                PlayerIndex index = gamer.SignedInGamer.PlayerIndex;

                InputHdr iHdr;
                iHdr.colInfo = null;
                iHdr.input = InputType.NotInitialied;
                iHdr.player = PlayerID.none;

                if (Instance.oldKeyState.IsKeyDown(Keys.D) || Instance.oldP1State.IsButtonDown(Buttons.DPadRight))
                {
                    iHdr.input = InputType.RotateRight;
                    if (gamer.IsHost)
                    {
                        iHdr.player = PlayerID.one;
                    }
                    else
                    {
                        iHdr.player = PlayerID.two;
                    }
                    iHdr.networked = false;
                    iHdr.colInfo = null;
                    OutputQueue.pushHeader(iHdr);
                }

                if (Instance.oldKeyState.IsKeyDown(Keys.A) || Instance.oldP1State.IsButtonDown(Buttons.DPadLeft))
                {
                    iHdr.input = InputType.RotateLeft;
                    if (gamer.IsHost)
                    {
                        iHdr.player = PlayerID.one;
                    }
                    else
                    {
                        iHdr.player = PlayerID.two;
                    }
                    iHdr.networked = false;
                    iHdr.colInfo = null;
                    OutputQueue.pushHeader(iHdr);
                }

                if (Instance.oldKeyState.IsKeyDown(Keys.W) || Instance.oldP1State.IsButtonDown(Buttons.DPadUp))
                {
                    iHdr.input = InputType.Forward;
                    if (gamer.IsHost)
                    {
                        iHdr.player = PlayerID.one;
                    }
                    else
                    {
                        iHdr.player = PlayerID.two;
                    }
                    iHdr.networked = false;
                    iHdr.colInfo = null;
                    OutputQueue.pushHeader(iHdr);
                }

                if ((Instance.oldKeyState.IsKeyDown(Keys.X) && Instance.keyboardState.IsKeyUp(Keys.X)))
                {
                    iHdr.input = InputType.FireMissile;
                    if (gamer.IsHost)
                    {
                        iHdr.player = PlayerID.one;
                    }
                    else
                    {
                        iHdr.player = PlayerID.two;
                    }
                    iHdr.networked = false;
                    iHdr.colInfo = null;
                    OutputQueue.pushHeader(iHdr);
                }
                else if ((Instance.oldP1State.IsButtonDown(Buttons.A) && Instance.player1Pad.IsButtonUp(Buttons.A)))
                {
                    iHdr.input = InputType.FireMissile;
                    if (gamer.IsHost)
                    {
                        iHdr.player = PlayerID.one;
                    }
                    else
                    {
                        iHdr.player = PlayerID.two;
                    }
                    iHdr.networked = false;
                    iHdr.colInfo = null;
                    OutputQueue.pushHeader(iHdr);
                }

                if (Instance.oldKeyState.IsKeyDown(Keys.C) && Instance.keyboardState.IsKeyUp(Keys.C))
                {
                    iHdr.input = InputType.DropBomb;
                    if (gamer.IsHost)
                    {
                        iHdr.player = PlayerID.one;
                    }
                    else
                    {
                        iHdr.player = PlayerID.two;
                    }
                    iHdr.networked = false;
                    iHdr.colInfo = null;
                    OutputQueue.pushHeader(iHdr);
                }
                else if (Instance.oldP1State.IsButtonDown(Buttons.B) && Instance.player1Pad.IsButtonUp(Buttons.B))
                {
                    iHdr.input = InputType.DropBomb;
                    if (gamer.IsHost)
                    {
                        iHdr.player = PlayerID.one;
                    }
                    else
                    {
                        iHdr.player = PlayerID.two;
                    }
                    iHdr.networked = false;
                    iHdr.colInfo = null;
                    OutputQueue.pushHeader(iHdr);
                }

                Instance.oldKeyState = Instance.keyboardState;
                Instance.oldP1State = Instance.player1Pad;
            }
        }

        private static InputManager Instance
        {
            get
            {
                if (imInstance == null)
                {
                    imInstance = new InputManager();
                }

                return imInstance;
            }
        }
    }
}
