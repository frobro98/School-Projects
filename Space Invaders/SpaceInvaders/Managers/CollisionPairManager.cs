using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionPairManager : Manager
    {
        private static CollisionPairManager cpInstance = null;

        public CollisionPairManager(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {
        }

        public static void setInstance(CollisionPairManager instance)
        {
            cpInstance = instance;
        }

        public static void initialize(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            if (cpInstance == null)
            {
                cpInstance = new CollisionPairManager(toCreate, willCreate);
            }
        }

        public static void setupCollisions()
        {
            // Collisions
            CollisionPair gridSide = CollisionPairManager.add(CollisionPair.Type.AlienSide, GameObject.Name.Grid, GameObject.Name.Wall);
            CollisionPair playerWall = CollisionPairManager.add(CollisionPair.Type.PlayerSide, GameObject.Name.Player, GameObject.Name.Wall);
            CollisionPair missileAlien = CollisionPairManager.add(CollisionPair.Type.AlienMissile, GameObject.Name.Grid, GameObject.Name.Missiles);
            CollisionPair missileTop = CollisionPairManager.add(CollisionPair.Type.MissileTop, GameObject.Name.Wall, GameObject.Name.Missiles);
            CollisionPair bombBottom = CollisionPairManager.add(CollisionPair.Type.BombBottom, GameObject.Name.Bombs, GameObject.Name.Wall);
            CollisionPair bombPlayer = CollisionPairManager.add(CollisionPair.Type.BombPlayer, GameObject.Name.Player, GameObject.Name.Bombs);
            CollisionPair missileBomb = CollisionPairManager.add(CollisionPair.Type.MissileBomb, GameObject.Name.Missiles, GameObject.Name.Bombs);
            CollisionPair gridPlayer = CollisionPairManager.add(CollisionPair.Type.AlienPlayer, GameObject.Name.Grid, GameObject.Name.Player);
            CollisionPair missileUFO = CollisionPairManager.add(CollisionPair.Type.MissileUFO, GameObject.Name.Missiles, GameObject.Name.UFO);
            CollisionPair shieldBomb = CollisionPairManager.add(CollisionPair.Type.ShieldBomb, GameObject.Name.Shields, GameObject.Name.Bombs);
            CollisionPair shieldGrid = CollisionPairManager.add(CollisionPair.Type.AlienShield, GameObject.Name.Grid, GameObject.Name.Shields);
            CollisionPair shieldMissile = CollisionPairManager.add(CollisionPair.Type.MissileShield, GameObject.Name.Missiles, GameObject.Name.Shields);
            CollisionPair sideUFO = CollisionPairManager.add(CollisionPair.Type.UFOSide, GameObject.Name.Wall, GameObject.Name.UFO);

            // Grid vs Wall Observers
            gridSide.attach(new GridMoveObserver());

            // Player vs Wall Observers
            playerWall.attach(new WallStopObserver());

            // Alien vs Missile Observers
            missileAlien.attach(new MissileDestroyObserver());
            missileAlien.attach(new AlienDeathObserver());
            missileAlien.attach(new AddScore());
            missileAlien.attach(new SpawnSplat());
            missileAlien.attach(new PlayAlienDeath());

            // Missile vs Top Observers
            missileTop.attach(new MissileDestroyObserver());
            missileTop.attach(new SpawnExplosion());

            // Bomb vs Bottom
            bombBottom.attach(new BombDestroyObserver());
            bombBottom.attach(new SpawnExplosion());

            // Bomb vs Player
            bombPlayer.attach(new BombDestroyObserver());
            bombPlayer.attach(new PlayerDeath());

            // Missile vs Bomb
            missileBomb.attach(new MissileDestroyObserver());
            missileBomb.attach(new BombDestroyObserver());
            missileBomb.attach(new SpawnExplosion());

            // Grid vs Player

            // Missile vs UFO
            missileUFO.attach(new MissileDestroyObserver());
            missileUFO.attach(new UFODestroyObserver());
            missileUFO.attach(new AddUFO());
            missileUFO.attach(new PlayUFODeath());

            // Shield vs Bomb
            shieldBomb.attach(new BombDestroyObserver());
            shieldBomb.attach(new ShieldDissolveObserver());

            // Shield vs Grid
            shieldGrid.attach(new ShieldDissolveObserver());

            // Shield vs Missile
            shieldMissile.attach(new MissileDestroyObserver());
            shieldMissile.attach(new ShieldDissolveObserver());

            // UFO vs Wall
            sideUFO.attach(new UFODelayDestroyObserver());
        }

        public override ManNode getManObject()
        {
            return new CollisionPair();
        }

        public static CollisionPair add(CollisionPair.Type type, GameObject.Name tA, GameObject.Name tB)
        {
            CollisionPair pair = (CollisionPair)Instance.baseAdd();

            pair.set(type, tA, tB);

            return pair;
        }

        public static void remove(CollisionPair.Type type)
        {
            Instance.baseRemove(type);
        }

        public static CollisionPair find(CollisionPair.Type type)
        {
            return (CollisionPair)Instance.baseFind(type);
        }

        public static void update()
        {
            CollisionPair pair = (CollisionPair)Instance.activeHead;

            while (pair != null)
            {
                pair.testCollision();

                pair = (CollisionPair)pair.next;
            }
        }

        private static CollisionPairManager Instance
        {
            get
            {
                return cpInstance;
            }
        }
    }
}
