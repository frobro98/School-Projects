using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Player
    {
        public enum PlayerNum
        {
            One,
            Two
        }

        // Managers specific to Players
        private SpriteBatchManager batchMan;
        private GameObjectManager gameObjMan;
        private TimeEventManager timeMan;
        private CollisionPairManager colPairMan;
        // Lives
        private const int maxLives = 3;
        private int currNumLives;

        private int score;

        private PlayerNum playerType;

        public Player(PlayerNum type = PlayerNum.One)
        {
            batchMan = new SpriteBatchManager(9, 1);
            gameObjMan = new GameObjectManager(11, 1);
            timeMan = new TimeEventManager(4, 2);
            colPairMan = new CollisionPairManager(13, 1);
            hookupManagers();
            initialPlayerSetup();

            playerType = type;
            currNumLives = maxLives;
        }

        public void initialPlayerSetup()
        {
            // HIERARCHY --------------------------------------------------------------------------
            setupRoots();

            // Wall creation
            Hierarchy wallTree = HierarchyFactory.create(Hierarchy.Walls.Walls, new Azul.Color(0.0f, 1.0f, 0.0f));

            WallFactory.attachTree(wallTree);
            WallFactory.create(TopWall.Side.Top);
            WallFactory.create(BottomWall.Side.Bottom);
            WallFactory.create(LeftWall.Side.Left);
            WallFactory.create(RightWall.Side.Right);

            // Shield row creation 
            Hierarchy shield1 = HierarchyFactory.create(Hierarchy.Shields.Shields, new Azul.Color(1f, 1f, 0f));
            Hierarchy shield2 = HierarchyFactory.create(Hierarchy.Shields.Shields, new Azul.Color(1f, 1f, 0f));
            Hierarchy shield3 = HierarchyFactory.create(Hierarchy.Shields.Shields, new Azul.Color(1f, 1f, 0f));
            Hierarchy shield4 = HierarchyFactory.create(Hierarchy.Shields.Shields, new Azul.Color(1f, 1f, 0f));

            ShieldFactory.setRoot(shield1);
            ShieldFactory.createShield(GameObject.Name.Shields, 100f, 150f);
            ShieldFactory.setRoot(shield2);
            ShieldFactory.createShield(GameObject.Name.Shields, 350f, 150f);
            ShieldFactory.setRoot(shield3);
            ShieldFactory.createShield(GameObject.Name.Shields, 600f, 150f);
            ShieldFactory.setRoot(shield4);
            ShieldFactory.createShield(GameObject.Name.Shields, 850f, 150f);

            // Timer Events
            AnimatedSprite squidAni = new AnimatedSprite(SpriteEnum.Squid, ImageEnum.Squid_2);
            AnimatedSprite octoAni = new AnimatedSprite(SpriteEnum.Octo, ImageEnum.Octo_2);
            AnimatedSprite crabAni = new AnimatedSprite(SpriteEnum.Crab, ImageEnum.Crab_2);
            Movement gridMove = new Movement();
            SpawnBomb spawn = new SpawnBomb(GameObject.Name.Grid);
            SpawnUFO ufoSpawn = new SpawnUFO();

            CommandContainer.add(ufoSpawn, TimeEvent.EventType.BombSpawn);
            CommandContainer.add(spawn, TimeEvent.EventType.BombSpawn);
            CommandContainer.add(crabAni, TimeEvent.EventType.Animation, Index.Index_2);
            CommandContainer.add(squidAni, TimeEvent.EventType.Animation, Index.Index_1);
            CommandContainer.add(octoAni, TimeEvent.EventType.Animation, Index.Index_0);
            CommandContainer.add(gridMove, TimeEvent.EventType.Movement);

            float moveTime = GameManager.MoveFrameTime;

            TimeEventManager.add(moveTime, gridMove, TimeEvent.EventType.Movement);
            TimeEventManager.add(moveTime, octoAni, TimeEvent.EventType.Animation, Index.Index_0);
            TimeEventManager.add(moveTime, squidAni, TimeEvent.EventType.Animation, Index.Index_1);
            TimeEventManager.add(moveTime, crabAni, TimeEvent.EventType.Animation, Index.Index_2);
            TimeEventManager.add(2.0f, spawn, TimeEvent.EventType.BombSpawn);
            TimeEventManager.add(12f, ufoSpawn, TimeEvent.EventType.UFO);

            CollisionPairManager.setupCollisions();
        }

        private void setupRoots()
        {
            // Grid creation ------------------------------------------------------------------
            HierarchyFactory.create(Hierarchy.Grid.Grid, new Azul.Color(1.0f, 1.0f, 0.0f));

            // Player creation ----------------------------------------------------------------
            HierarchyFactory.create(Hierarchy.Players.Player, new Azul.Color(0.0f, 0.0f, 1.0f));

            // Missile hierarchy creation -----------------------------------------------------
            HierarchyFactory.create(Hierarchy.Missiles.Missiles, new Azul.Color(1.0f, 1.0f, 0.0f));

            // Bomb hierarchy creation --------------------------------------------------------
            HierarchyFactory.create(Hierarchy.Bombs.Bombs, new Azul.Color(1f, 1f, 0f));
            

            // UFO hierarchy creation ---------------------------------------------------------
            HierarchyFactory.create(Hierarchy.UFOs.UFO, new Azul.Color(1f, 0f, 0f));
           
            // Shield hierarchy creation ------------------------------------------------------
            HierarchyFactory.create(Hierarchy.Shields.Shields, new Azul.Color(1f, 1f, 0f));


            PlayerFactory.attachTree(GameObjectManager.find(GameObject.Name.Player));
            BombFactory.setRoot(GameObjectManager.find(GameObject.Name.Bombs));
            UFOFactory.setTree(GameObjectManager.find(GameObject.Name.UFO));

            PlayerFactory.create(PlayerShip.PlayerName.Player, 512, 100);
        }

        public void hookupManagers()
        {
            SpriteBatchManager.setInstance(this.batchMan);
            CollisionPairManager.setInstance(this.colPairMan);
            GameObjectManager.setInstance(this.gameObjMan);
            TimeEventManager.setInstance(this.timeMan);

            setupSpriteBatches();

            AlienFactory.initialize(BatchGroup.BatchType.Aliens);
            PlayerFactory.initialize(BatchGroup.BatchType.Player);
            HierarchyFactory.initialize(BatchGroup.BatchType.Aliens);
            MissileFactory.initialize(BatchGroup.BatchType.Missiles);
            ShieldFactory.initialize(BatchGroup.BatchType.Shields);
            BombFactory.initialize(BatchGroup.BatchType.Bombs);
            UFOFactory.initialize(BatchGroup.BatchType.UFO);
            WallFactory.initialize();
        }

        public void setupSpriteBatches()
        {
            SpriteBatchManager.add(BatchGroup.BatchType.Aliens);
            SpriteBatchManager.add(BatchGroup.BatchType.Shields);
            SpriteBatchManager.add(BatchGroup.BatchType.Player);
            SpriteBatchManager.add(BatchGroup.BatchType.Missiles);
            SpriteBatchManager.add(BatchGroup.BatchType.Shields);
            SpriteBatchManager.add(BatchGroup.BatchType.Bombs);
            SpriteBatchManager.add(BatchGroup.BatchType.UFO);
            SpriteBatchManager.add(BatchGroup.BatchType.Explosions);
            BatchGroup colGroup = SpriteBatchManager.add(BatchGroup.BatchType.Collisions, false);
        }

        public int Lives
        {
            get
            {
                return currNumLives;
            }
            set
            {
                currNumLives = value;
                if (currNumLives <= 0)
                {
                    GameManager.endGame();
                }
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

    }
}
