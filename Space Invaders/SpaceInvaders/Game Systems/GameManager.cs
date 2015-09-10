using System;

namespace SpaceInvaders
{
    class GameManager
    {
        private static GameManager gmInstance = null;
        private GameHUD hud;
        private int numAliens;
        //private TreeNode alienTree;
        private float moveFrameTime;
        private bool gameStarted;
        private int wave;

        private GameManager()
        {
            hud = new GameHUD();
            numAliens = 0;
            //alienTree = null;
            moveFrameTime = 1f;
            hud.setSplashScreen();
            gameStarted = false;
            wave = 0;
        }

        public static void initialize()
        {
            gmInstance = new GameManager();
            
        }

        public static void drawHUD()
        {
            Instance.hud.draw();
        }

        public static void startGame()
        {
            //PlayerManager.getCurrentPlayer().initialize();
            //Instance.alienTree = HierarchyFactory.create(Hierarchy.Grid.Grid, new Azul.Color(1.0f, 1.0f, 0.0f));
            AlienFactory.createGrid(Instance.wave);
            Instance.numAliens = 55;
        }

        public static void endGame()
        {
            PlayerManager.endGame();
            Instance.gameStarted = false;
            Instance.hud.setSplashScreen();
            SoundManager.stopUFO();
        }

        public static void playerDeath()
        {
            --PlayerManager.getCurrentPlayer().Lives;
        }

        public static void nextWave()
        {
            ++Instance.wave;
            AlienFactory.createGrid(Instance.wave);
            Instance.numAliens = 55;
            Instance.moveFrameTime = 1f;
            SoundManager.resetMovement();
        }

        public static void update(float totalTime)
        {
            if (Instance.gameStarted)
            {
                DestroyManager.deleteObjects();
                TimeEventManager.update(totalTime);
                CollisionPairManager.update();
                GameObjectManager.update();
            }
            else
            {
                if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_1))
                {
                    PlayerManager.set1Player();
                    Instance.gameStarted = true;
                    Instance.hud.setGameScreen();
                    GameManager.startGame();
                }
                else if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_2))
                {
                    PlayerManager.set2Players();
                    Instance.gameStarted = true;
                    Instance.hud.setGameScreen();
                    GameManager.startGame();
                }
            }
            Instance.hud.update();
        }

        public static void draw()
        {
            if (Instance.gameStarted)
            {
                SpriteBatchManager.draw();
            }
            GameManager.drawHUD();
        }

        private static GameHUD HUD
        {
            get
            {
                return Instance.hud;
            }
        }

        private static GameManager Instance
        {
            get
            {
                if(gmInstance == null)
                {
                    gmInstance = new GameManager();
                }

                return gmInstance;
            }
        }

        public static int TotalAliens
        {
            get
            {
                return Instance.numAliens;
            }
            set
            {
                Instance.numAliens = value;

                if (Instance.numAliens <= 0)
                {
                    TimeEventManager.add(1f, new ResetGrid());
                    SoundManager.ResetingWave = true;
                }
            }
        }

        public static float MoveFrameTime
        {
            get
            {
                return Instance.moveFrameTime;
            }
            set
            {
                Instance.moveFrameTime = value;
            }
        }
    }
}
