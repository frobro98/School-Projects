using System;

namespace SpaceInvaders
{
    sealed class Game : Azul.Engine
    {
        //GameHUD hud;
        
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            Azul.Camera.setWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            AssetManager.initialize();
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {

            setClearBufferColor(new Azul.Color(0f, 0f, 0.0f));

            AssetManager.loadContent();
            
            //GameManager.startGame();
        
        }
       
        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update(float totalTime)
        {

            GameManager.update(totalTime);

        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {

            GameManager.draw();
            //hud.draw();
            
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            //TextureManager.print("TextureManager:");
            //ImageManager.print("ImageManager: ");
            //GameSpriteManager.print("GameSpriteManager:");
            //SpriteBatchManager.print("SpriteBatchManager:");
            //GameObjectManager.print("GameObjectManager:");
            //CollisionSpriteManager.print("CollisionSpriteManager:");
        }


        private void checkInput()
        {

           
        }

    }
}
