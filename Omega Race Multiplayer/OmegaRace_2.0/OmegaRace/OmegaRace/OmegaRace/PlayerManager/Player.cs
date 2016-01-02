using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework;
using Box2D.XNA;
using OmegaRace;

namespace CollisionManager
{

    enum PlayerID
    {
        one,
        two,
        none
    }

    enum PlayerState
    {
        alive,
        dead
    }

    


    class Player
    {
        public PlayerID id;
        public int lives;

        public Ship playerShip;

        // Life Sprites
        public Sprite_Proxy lifeSprite1;
        public Sprite_Proxy lifeSprite2;
        public Sprite_Proxy lifeSprite3;

        // Bomb Sprites
        public Sprite_Proxy bombSprite1;
        public Sprite_Proxy bombSprite2;
        public Sprite_Proxy bombSprite3;
        public Sprite_Proxy bombSprite4;
        public Sprite_Proxy bombSprite5;

        private Sprite emptySprite;
        private Sprite bombSprite;

        public PlayerState state;
        public Color color;

        private int numMissiles;
        private const int maxNumMissiles = 3;
        
        private int bombSpriteIndex;
        private GameObjType missileType;

        public Player(PlayerID _id)
        {
            lives = 4;
            id = _id;
            createLives(id);

            state = PlayerState.alive;

            emptySprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.box);

            if (_id == PlayerID.one)
            {
                bombSprite = new Sprite(SpriteEnum.Bomb, 0, 0, 50, 50, true, 0,
                             ImageManager.Instance().getImage(ImageEnum.bluebomb1), false);
                missileType = GameObjType.p1missiles;
            }
            else
            {
                bombSprite = new Sprite(SpriteEnum.Bomb, 0, 0, 50, 50, true, 0,
                             ImageManager.Instance().getImage(ImageEnum.greenbomb1), false);
                missileType = GameObjType.p2missiles;
            }

            bombSpriteIndex = 5;
            numMissiles = 0;
        }

       

        public bool Alive()
        {
            if (state == PlayerState.alive)
                return true;
            else
                return false;
        }

        public bool outOfLives()
        {
            if (lives > 0)
                return true;
            else
                return false;
        }

        private void createLives(PlayerID _id)
        {

            switch (_id)
            {
                case PlayerID.one:
                    {
                        createP1Lives();
                        break;
                    }

                case PlayerID.two:
                    {
                        createP2Lives();
                        break;
                    }
            }

            
             
        }

        private void createP1Lives()
        {

            // Ship Sprites
            Sprite shipSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.Ship);

            Sprite_Proxy pShip1 = new Sprite_Proxy(shipSprite, 95, 85, 0.4f, Color.Blue);
            Sprite_Proxy pShip2 = new Sprite_Proxy(shipSprite, 110, 85, 0.4f, Color.Blue);
            Sprite_Proxy pShip3 = new Sprite_Proxy(shipSprite, 125, 85, 0.4f, Color.Blue);

            pShip1.rotation = -(float)(90.0f * (Math.PI / 180.0f));
            pShip2.rotation = -(float)(90.0f * (Math.PI / 180.0f));
            pShip3.rotation = -(float)(90.0f * (Math.PI / 180.0f));

            SBNode shipBatch = SpriteBatchManager.Instance().getBatch(batchEnum.ships);

            shipBatch.addDisplayObject(pShip1);
            shipBatch.addDisplayObject(pShip2);
            shipBatch.addDisplayObject(pShip3);

            lifeSprite1 =  pShip3;
            lifeSprite2 =  pShip2;
            lifeSprite3 =  pShip1;

            color = Color.Blue;

            ///////////

            // Bomb Sprites
            Sprite bSprite1 = new Sprite(SpriteEnum.Bomb, 0, 0, 50, 50, true, 0,
                         ImageManager.Instance().getImage(ImageEnum.bluebomb1), false);

            Sprite_Proxy pBomb1 = new Sprite_Proxy(bSprite1, 93, 95, 0.5f, Color.Blue);
            Sprite_Proxy pBomb2 = new Sprite_Proxy(bSprite1, 101, 95, 0.5f, Color.Blue);
            Sprite_Proxy pBomb3 = new Sprite_Proxy(bSprite1, 109, 95, 0.5f, Color.Blue);
            Sprite_Proxy pBomb4 = new Sprite_Proxy(bSprite1, 117, 95, 0.5f, Color.Blue);
            Sprite_Proxy pBomb5 = new Sprite_Proxy(bSprite1, 125, 95, 0.5f, Color.Blue);

            SBNode bombBatch = SpriteBatchManager.Instance().getBatch(batchEnum.bomb);

            bombBatch.addDisplayObject(pBomb1);
            bombBatch.addDisplayObject(pBomb2);
            bombBatch.addDisplayObject(pBomb3);
            bombBatch.addDisplayObject(pBomb4);
            bombBatch.addDisplayObject(pBomb5);

            bombSprite1 = pBomb1;
            bombSprite2 = pBomb2;
            bombSprite3 = pBomb3;
            bombSprite4 = pBomb4;
            bombSprite5 = pBomb5;

        }

        private void createP2Lives()
        {
            Sprite shipSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.Ship);

            Sprite_Proxy pShip1 = new Sprite_Proxy(shipSprite, 175, 85, 0.4f, Color.Chartreuse);
            Sprite_Proxy pShip2 = new Sprite_Proxy(shipSprite, 190, 85, 0.4f, Color.Chartreuse);
            Sprite_Proxy pShip3 = new Sprite_Proxy(shipSprite, 205, 85, 0.4f, Color.Chartreuse);

            pShip1.rotation = -(float)(90.0f * (Math.PI / 180.0f));
            pShip2.rotation = -(float)(90.0f * (Math.PI / 180.0f));
            pShip3.rotation = -(float)(90.0f * (Math.PI / 180.0f));

            SBNode shipBatch = SpriteBatchManager.Instance().getBatch(batchEnum.ships);

            shipBatch.addDisplayObject(pShip1);
            shipBatch.addDisplayObject(pShip2);
            shipBatch.addDisplayObject(pShip3);

            lifeSprite1 = pShip1;
            lifeSprite2 = pShip2;
            lifeSprite3 = pShip3;

            color = Color.Chartreuse;

            // Bomb Sprites
            Sprite bSprite1 = new Sprite(SpriteEnum.Bomb, 0, 0, 50, 50, true, 0,
                         ImageManager.Instance().getImage(ImageEnum.greenbomb1), false);

            Sprite_Proxy pBomb1 = new Sprite_Proxy(bSprite1, 175, 95, 0.5f, Color.Chartreuse);
            Sprite_Proxy pBomb2 = new Sprite_Proxy(bSprite1, 183, 95, 0.5f, Color.Chartreuse);
            Sprite_Proxy pBomb3 = new Sprite_Proxy(bSprite1, 191, 95, 0.5f, Color.Chartreuse);
            Sprite_Proxy pBomb4 = new Sprite_Proxy(bSprite1, 199, 95, 0.5f, Color.Chartreuse);
            Sprite_Proxy pBomb5 = new Sprite_Proxy(bSprite1, 207, 95, 0.5f, Color.Chartreuse);

            SBNode bombBatch = SpriteBatchManager.Instance().getBatch(batchEnum.bomb);

            bombBatch.addDisplayObject(pBomb1);
            bombBatch.addDisplayObject(pBomb2);
            bombBatch.addDisplayObject(pBomb3);
            bombBatch.addDisplayObject(pBomb4);
            bombBatch.addDisplayObject(pBomb5);

            bombSprite1 = pBomb1;
            bombSprite2 = pBomb2;
            bombSprite3 = pBomb3;
            bombSprite4 = pBomb4;
            bombSprite5 = pBomb5;
        }

        public void setShip(Ship s)
        {
            playerShip = s;
        }

        private bool missileAvailable()
        {
            if (numMissiles < maxNumMissiles)
                return true;
            else
                return false;
        }


        public void createMissile()
        {
            if (state == PlayerState.alive && missileAvailable())
            {
                Ship pShip = playerShip;
                Body pShipBody = pShip.physicsObj.body;

                Sprite missileSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.Missile);
                Sprite_Proxy proxyMissile = new Sprite_Proxy(missileSprite, (int)pShip.spriteRef.pos.X, (int)pShip.spriteRef.pos.Y, 0.5f, pShip.spriteRef.color);
                Missile missile = new Missile(missileType, proxyMissile, id);

                SBNode missileBatch = SpriteBatchManager.Instance().getBatch(batchEnum.missiles);
                missileBatch.addDisplayObject(proxyMissile);

                World world = Game1.GameInstance.getWorld();

                var missileShape = new PolygonShape();

                missileShape.SetAsBox(3, 3);

                var fd = new FixtureDef();
                fd.shape = missileShape;
                fd.restitution = 0.0f;
                fd.friction = 0.0f;
                fd.density = 0.0001f;
                fd.userData = missile;

                // Grab ship orientation vector
                Vector2 direction = new Vector2((float)(Math.Cos(pShipBody.GetAngle())), (float)(Math.Sin(pShipBody.GetAngle())));
                direction.Normalize();

                BodyDef bd = new BodyDef();
                bd.fixedRotation = true;

                bd.type = BodyType.Dynamic;
                bd.position = (new Vector2(pShip.spriteRef.pos.X, pShip.spriteRef.pos.Y)) + (direction * 10);



                var body = world.CreateBody(bd);
                body.SetBullet(true);
                body.Rotation = pShipBody.Rotation;
                body.CreateFixture(fd);
                body.SetUserData(missile);


                direction *= 1000;

                body.ApplyLinearImpulse(direction, body.GetWorldCenter());




                GameObjManager.Instance().addGameObj(missile);
                PhysicsMan.Instance().addPhysicsObj(missile, body);

                if (numMissiles < maxNumMissiles)
                    numMissiles++;
            }
        }

        public void increaseNumMissiles()
        {
            if(numMissiles > 0)
                numMissiles--;
        }

        public void removeBombSprite()
        {
            switch (bombSpriteIndex)
            {
                case 5:
                    bombSprite1.sprite = emptySprite;
                    bombSprite1.color = Color.Black;
                    bombSpriteIndex--;
                    break;

                case 4:
                    bombSprite2.sprite = emptySprite;
                    bombSprite2.color = Color.Black;
                    bombSpriteIndex--;
                    break;

                case 3:
                    bombSprite3.sprite = emptySprite;
                    bombSprite3.color = Color.Black;
                    bombSpriteIndex--;
                    break;

                case 2:
                    bombSprite4.sprite = emptySprite;
                    bombSprite4.color = Color.Black;
                    bombSpriteIndex--;
                    break;

                case 1:
                    bombSprite5.sprite = emptySprite;
                    bombSprite5.color = Color.Black;
                    bombSpriteIndex--;
                    break;
            }

        }

        public void addBombSprite()
        {
            switch (bombSpriteIndex)
            {
                case 0:
                    bombSprite5.sprite = bombSprite;
                    bombSprite5.color = color;
                    bombSpriteIndex++;
                    break;

                case 1:
                    bombSprite4.sprite = bombSprite;
                    bombSprite4.color = color;
                    bombSpriteIndex++;
                    break;

                case 2:
                    bombSprite3.sprite = bombSprite;
                    bombSprite3.color = color;
                    bombSpriteIndex++;
                    break;

                case 3:
                    bombSprite2.sprite = bombSprite;
                    bombSprite2.color = color;
                    bombSpriteIndex++;
                    break;

                case 4:
                    bombSprite1.sprite = bombSprite;
                    bombSprite1.color = color;
                    bombSpriteIndex++;
                    break;
            }
        }

    }
}
