using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CollisionManager;
using SpriteAnimation;
using Box2D.XNA;
using NetworkedOmegaRace;

namespace OmegaRace
{
    public enum gameState
    {
        ready, // Flashes Ready? until the timer is up
        game, // The main game mode
        pause,
        winner, // Displays the winner
        lobby,
        mainmenu
    };

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        public GraphicsDeviceManager Graphics
        {
            get { return graphics; }
        }

        private static Game1 Game;
        public static Game1 GameInstance
        {
            get { return Game; }
        }

        private static Camera camera;
        public static Camera Camera
        {
            get { return camera; }
        }


        // Menu stuff
        Text menuTex;
        Image menuImg;
        Sprite menuSprite;
        private Sprite_Proxy menuProxy;
        public Sprite_Proxy MenuProxy
        {
            get { return menuProxy; }
        }
        SpriteBatch menuBatch;

        // Keyboard and Xbox Controller states
        KeyboardState oldState;
        KeyboardState newState;

        GamePadState P1oldPadState;
        GamePadState P1newPadState;

        GamePadState P2oldPadState;
        GamePadState P2newPadState;


        // For flipping game states
        public static gameState state;

        private NetworkController sessionController;

        // Box2D world
        World world;
        public World getWorld()
        {
            return world;
        }

        public Rectangle gameScreenSize;


        // Quick reference for Input 
        Player player1;
        Player player2;


        // Max ship speed
        int shipSpeed;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 800;

            gameScreenSize = new Rectangle(0, 0, 800, 500);

            state = gameState.ready;

            world = new World(new Vector2(0, 0), false);

            shipSpeed = 200;

            Game = this;

            Components.Add(new GamerServicesComponent(this));

            sessionController = new NetworkController();
        }

        public static NetworkController Network
        {
            get
            {
                return GameInstance.sessionController;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           

            camera = new Camera(GraphicsDevice.Viewport, Vector2.Zero);

            state = gameState.game;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here

                world = new World(new Vector2(0, 0), true);

                myContactListener myContactListener = new myContactListener();

                

                world.ContactListener = myContactListener;


                Data.Instance().createData();

            if(state != gameState.winner)
                state = gameState.mainmenu;

                player1 = PlayerManager.Instance().getPlayer(PlayerID.one);
                player2 = PlayerManager.Instance().getPlayer(PlayerID.two);

                menuTex = new Text("MainMenu", TextEnum.menu, 0, 20, 20, false, SpriteAnimation.Type.Text_Sprite);
                menuImg = new Image(ImageEnum.menu, 0, 0, 800, 480, menuTex);
                menuSprite = new Sprite(SpriteEnum.menu, 0, 0, 800, 500, false, 0, menuImg, false);
                menuProxy = new Sprite_Proxy(menuSprite, 400, 240, 1, Color.White);
                menuBatch = new SpriteBatch(GraphicsDevice);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);

                GraphicsDevice.Clear(Color.Black);

            if (sessionController.Session != null)
            {
                if (state == gameState.game)
                {

                    InputQueue.updateInfo();

                    if (!Network.IsNetworked)
                    {
                        UpdateLocal(gameTime);
                    }
                    else if (Network.Session.IsHost)
                    {
                        UpdateServer(gameTime);
                    }

                    GameObjManager.Instance().Update(world);

                    InputManager.updateInputs();

                    ScoreManager.Instance().Update();

                    OutputQueue.flush();

                    Timer.Process(gameTime);
                }

            }

            sessionController.Update();

            Game1.Camera.Update(gameTime);

        }

        protected void UpdateServer(GameTime gameTime)
        {
            world.Step((float)gameTime.ElapsedGameTime.TotalSeconds, 5, 8);

            PhysicsMan.Instance().Update();
        }

        protected void UpdateLocal(GameTime gameTime)
        {
            world.Step((float)gameTime.ElapsedGameTime.TotalSeconds, 5, 8);

            PhysicsMan.Instance().Update();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //if (sessionController.Session != null)
            //{
                if (state == gameState.game)
                {
                    SpriteBatchManager.Instance().process();
                }
            //}
                else if (state == gameState.mainmenu)
                {
                    ScreenWrite.drawMainMenu();
                }
                else if(state == gameState.lobby)
                {
                    ScreenWrite.drawMenuScreen();
                }
                else if (state == gameState.winner)
                {
                    ScreenWrite.gameOverScreen();
                }

            

            base.Draw(gameTime);
        }

        public void GameOver()
        {
            state = gameState.winner;
            sessionController.Session.Dispose();
            sessionController.Session = null;

            resetData();
        }


        private void checkGameInput()
        {
            newState = Keyboard.GetState();
            P1newPadState = GamePad.GetState(PlayerIndex.One);
            P2newPadState = GamePad.GetState(PlayerIndex.Two);

            if (oldState.IsKeyDown(Keys.D) || P1oldPadState.IsButtonDown(Buttons.DPadRight))
            {
                player1.playerShip.physicsObj.body.Rotation += 0.1f;
            }

            if (oldState.IsKeyDown(Keys.A) || P1oldPadState.IsButtonDown(Buttons.DPadLeft))
            {

                player1.playerShip.physicsObj.body.Rotation -= 0.1f;
            }

            if (oldState.IsKeyDown(Keys.W) || P1oldPadState.IsButtonDown(Buttons.DPadUp))
            {
                Ship Player1Ship = player1.playerShip;

                Vector2 direction = new Vector2((float)(Math.Cos(Player1Ship.physicsObj.body.GetAngle())), (float)(Math.Sin(Player1Ship.physicsObj.body.GetAngle())));

                direction.Normalize();

                direction *= shipSpeed;

                Player1Ship.physicsObj.body.ApplyLinearImpulse(direction, Player1Ship.physicsObj.body.GetWorldCenter());


            }

            if ((oldState.IsKeyDown(Keys.X) && newState.IsKeyUp(Keys.X)) || (P1oldPadState.IsButtonDown(Buttons.A) && P1newPadState.IsButtonUp(Buttons.A)))
            {
                player1.createMissile();
            }

            if (oldState.IsKeyDown(Keys.C) && newState.IsKeyUp(Keys.C) || (P1oldPadState.IsButtonDown(Buttons.B) && P1newPadState.IsButtonUp(Buttons.B)))
            {
                if(player1.state == PlayerState.alive)
                    GameObjManager.Instance().createBomb(PlayerID.one);

            }

            if (oldState.IsKeyDown(Keys.Right) || P2oldPadState.IsButtonDown(Buttons.DPadRight))
            {
                player2.playerShip.physicsObj.body.Rotation += 0.1f;

            }

            if (oldState.IsKeyDown(Keys.Left) || P2oldPadState.IsButtonDown(Buttons.DPadLeft))
            {
                player2.playerShip.physicsObj.body.Rotation -= 0.1f;
            }


            if (oldState.IsKeyDown(Keys.Up) || P2oldPadState.IsButtonDown(Buttons.DPadUp))
            {
                Ship Player2Ship = player2.playerShip;

                Vector2 direction = new Vector2((float)(Math.Cos(Player2Ship.physicsObj.body.GetAngle())), (float)(Math.Sin(Player2Ship.physicsObj.body.GetAngle())));

                direction.Normalize();

                direction *= shipSpeed;

                Player2Ship.physicsObj.body.ApplyLinearImpulse(direction, Player2Ship.physicsObj.body.GetWorldCenter());

            }

            if ((oldState.IsKeyDown(Keys.OemQuestion) && newState.IsKeyUp(Keys.OemQuestion)) || (P2oldPadState.IsButtonDown(Buttons.A) && P2newPadState.IsButtonUp(Buttons.A)))
            {
                player2.createMissile();
            }

            if (oldState.IsKeyDown(Keys.OemPeriod) && newState.IsKeyUp(Keys.OemPeriod) || (P2oldPadState.IsButtonDown(Buttons.B) && P2newPadState.IsButtonUp(Buttons.B)))
            {
                if (player2.state == PlayerState.alive && BombManager.Instance().bombAvailable(PlayerID.two))
                    GameObjManager.Instance().createBomb(PlayerID.two);
            }


            else { }



            P1oldPadState = P1newPadState;
            P2oldPadState = P2newPadState;
            oldState = newState;
        }

        private void clearData()
        {
            TextureManager.Instance().clear();
            ImageManager.Instance().clear();
            SpriteBatchManager.Instance().clear();
            SpriteProxyManager.Instance().clear();
            DisplayManager.Instance().clear();
            AnimManager.Instance().clear();
            GameObjManager.Instance().clear();
            PhysicsMan.Instance().clear();
            Timer.Clear();
            PlayerManager.Instance().clear();
            BombManager.Instance().clear();
        }

        public void resetData()
        {
            clearData();

            LoadContent();

            ScoreManager.Instance().createData();

            //state = gameState.game;
        }
    }
}
