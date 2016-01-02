using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using CollisionManager;
using Microsoft.Xna.Framework;
using Box2D.XNA;

namespace OmegaRace
{
    class Data
    {
        private static Data instance;

        private float fencePostScale;
        private float fenceScale;
        private float shipScale;

        private Data()
        {
            fencePostScale = 0.5f;
            fenceScale = 1.0f;
            shipScale = 0.4f;
        }

        public static Data Instance()
        {
            if (instance == null)
                instance = new Data();
            return instance;
        }

        public void createData()
        {
            createShip1(new Vector2(150, 60), - (float)(90.0f * (Math.PI / 180.0f)));
            createShip2(new Vector2(150, 130),  (float)(90.0f * (Math.PI / 180.0f)));
            createFences();
            createFencePosts();
            createCenterFences();
        }

        public void createShip1(Vector2 pos, float _rot)
        {
            World world = Game1.GameInstance.getWorld();

            ////////////////  For Sprite System use ///////////////
            Sprite shipSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.Ship);
            Sprite_Proxy proxyShip = new Sprite_Proxy(shipSprite, pos.X, pos.Y, shipScale, Color.Blue);
            Ship p1 = new Ship(GameObjType.p1ship, proxyShip);


            SBNode shipBatch = SpriteBatchManager.Instance().getBatch(batchEnum.ships);
            shipBatch.addDisplayObject(proxyShip);

            //////////////////////////////////////
           

            // Box2D Body Setup/////////////////////////
            var shipShape = new PolygonShape();
            Vector2[] verts = new Vector2[5];


            verts[0] = new Vector2(-5.0f, -5.0f);
            verts[1] = new Vector2(4.8f, -0.10f);
            verts[2] = new Vector2(5.0f, 0.00f);
            verts[3] = new Vector2(4.8f, 0.10f);
            verts[4] = new Vector2(-5.0f, 5.0f);

            shipShape.Set(verts, 5);
            shipShape._centroid = new Vector2(0, 0);
            

            var fd = new FixtureDef();
            fd.shape = shipShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = p1;

            BodyDef bd = new BodyDef();
            bd.allowSleep = false;
            bd.fixedRotation = true;
            bd.type = BodyType.Dynamic;
            bd.position = p1.spriteRef.pos;
            

            var body = world.CreateBody(bd);
           
            body.CreateFixture(fd);
            body.SetUserData(p1);
            body.Rotation = _rot;
            ///////////////////////////////////////

            // Set sprite body reference

            
            PhysicsMan.Instance().addPhysicsObj(p1, body);
            //////////////////

            // Set Player's ship and add it to the GameObjManager //////////////
            PlayerManager.Instance().getPlayer(PlayerID.one).setShip(p1);

            GameObjManager.Instance().addGameObj(p1); 
        }

        public void createShip2(Vector2 pos, float _rot)
        {
            World world = Game1.GameInstance.getWorld();

            ////////////////
            Sprite shipSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.Ship);
            Sprite_Proxy proxyShip = new Sprite_Proxy(shipSprite, pos.X, pos.Y, shipScale, Color.Chartreuse);
            Ship p2 = new Ship(GameObjType.p2ship, proxyShip);


            SBNode shipBatch = SpriteBatchManager.Instance().getBatch(batchEnum.ships);
            shipBatch.addDisplayObject(proxyShip);

            ///////////////

            var shipShape = new PolygonShape();

            Vector2[] verts = new Vector2[5];

            verts[0] = new Vector2(-5.0f, -5.0f);
            verts[1] = new Vector2(4.8f, -0.10f);
            verts[2] = new Vector2(5.0f, 0.00f);
            verts[3] = new Vector2(4.8f, 0.10f);
            verts[4] = new Vector2(-5.0f, 5.0f);

            shipShape.Set(verts, 5);
            shipShape._centroid = new Vector2(0, 0);

            var fd = new FixtureDef();
            fd.shape = shipShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = p2;

            BodyDef bd = new BodyDef();
            bd.allowSleep = false;
            bd.fixedRotation = true;
            bd.type = BodyType.Dynamic;
            bd.position = new Vector2(p2.spriteRef.pos.X, p2.spriteRef.pos.Y);
           
            


            var body = world.CreateBody(bd);

            body.CreateFixture(fd);
            body.SetUserData(p2);
            body.Rotation = _rot;



            PhysicsMan.Instance().addPhysicsObj(p2, body);

            //////////////////

            PlayerManager.Instance().getPlayer(PlayerID.two).setShip(p2);

            GameObjManager.Instance().addGameObj(p2);
        }

        private void createFences()
        {
            // Top Wall //////
            createFence1();
            createFence2();
            createFence3();
            createFence4();
            /////////////

            // Right Wall  ///////
            createFence5();
            createFence6();
            
            // Left Wall ////////////
            createFence7();
            createFence8();
            ////////////////

            // Bottom Wall ////////
            createFence9();
            createFence10();
            createFence11();
            createFence12();
        }

        private void createFence1()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////


            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence1);

           // Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.Wall);
            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 40, 5, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);
            

            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width /2 , wall1.spriteRef.sprite.height / 2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.allowSleep = false;
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));


            GameObjManager.Instance().addGameObj(wall1);

            PhysicsMan.Instance().addPhysicsObj(wall1, body);

            /////////////////////
           
        }

        private void createFence2()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////


            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence2);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 112, 5, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2 , wall1.spriteRef.sprite.height/2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }

        private void createFence3()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////


            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence3);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 186, 5, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2 , wall1.spriteRef.sprite.height/2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }

        private void createFence4()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////


            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence4);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 262, 5, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2, wall1.spriteRef.sprite.height/2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));


            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }

        private void createFence5()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence5);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 300, 50, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            PolygonShape wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2, wall1.spriteRef.sprite.height/2 );

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);



            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
        }

        private void createFence6()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence6);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 300, 143, fenceScale, Color.White);

            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2 , wall1.spriteRef.sprite.height/2 );

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);


            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
        }

        private void createFence7()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence7);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 5, 50, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2 , wall1.spriteRef.sprite.height/2 );

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);


            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
        }

        private void createFence8()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence8);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 5, 143, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2 , wall1.spriteRef.sprite.height/2 );

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);


            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
        }

        private void createFence9()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence9);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 40, 190, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2, wall1.spriteRef.sprite.height/2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
           
        }

        private void createFence10()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence10);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 112, 190, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2 , wall1.spriteRef.sprite.height/2 );

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }

        private void createFence11()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence11);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 186, 190, fenceScale, Color.White);
            
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2 , wall1.spriteRef.sprite.height/2 );

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }

        private void createFence12()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fence12);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 262, 190, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width/2 , wall1.spriteRef.sprite.height/2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }

        private void createCenterFences()
        {
            // Top wall
            createTopFence();


            // Bottom Wall //
            createBotFence();

            // Right wall //
            createRightFence();

            // Left Wall //
            createLeftFence();

        }

        // Center Fences
        private void createTopFence()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fenceCTop);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 150, 71, fenceScale, Color.White);
            
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width / 2, wall1.spriteRef.sprite.height / 2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }

        private void createBotFence()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////
            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fenceCBot);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 150, 119, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width / 2, wall1.spriteRef.sprite.height / 2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);
            body.Rotation = (float)(90.0f * (Math.PI / 180.0f));

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }

        private void createRightFence()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fenceCRight);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 225, 95, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width / 2, wall1.spriteRef.sprite.height / 2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }

        private void createLeftFence()
        {
            World world = Game1.GameInstance.getWorld();

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite wallSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.fenceCLeft);

            DisplayManager.Instance().addDisplayObj(SpriteEnum.Wall, wallSprite);


            Sprite_Proxy wallProxy = new Sprite_Proxy(wallSprite, 75, 95, fenceScale, Color.White);
            Wall wall1 = new Wall(GameObjType.horzWalls, wallProxy);


            SBNode wallBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            wallBatch.addDisplayObject(wallProxy);

            //////////////////

            // Box2D /////////////

            var wallShape = new PolygonShape();

            wallShape.SetAsBox(wall1.spriteRef.sprite.width / 2, wall1.spriteRef.sprite.height / 2);

            var fd = new FixtureDef();
            fd.shape = wallShape;
            fd.restitution = 0.9f;
            fd.friction = 0.0f;
            fd.density = 1.0f;
            fd.userData = wall1;

            BodyDef bd = new BodyDef();
            bd.type = BodyType.Static;
            bd.position = wall1.spriteRef.pos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(wall1);

            GameObjManager.Instance().addGameObj(wall1);
            PhysicsMan.Instance().addPhysicsObj(wall1, body);
            /////////////////////
        }
        
        ////////////////
        
        private void createFencePosts()
        {

            Rectangle gameScreenSize = Game1.GameInstance.gameScreenSize;

            // Sprite Animation ///////////

            Sprite postSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.FencePost);

            int x = gameScreenSize.Width;

            // Top Wall ///////////
            Sprite_Proxy postProxy1 = new Sprite_Proxy(postSprite, 5, 5, fencePostScale, Color.White);
            Sprite_Proxy postProxy2 = new Sprite_Proxy(postSprite, 75, 5, fencePostScale, Color.White);
            Sprite_Proxy postProxy3 = new Sprite_Proxy(postSprite, 150, 5, fencePostScale, Color.White);
            Sprite_Proxy postProxy4 = new Sprite_Proxy(postSprite, 225, 5, fencePostScale, Color.White);
            Sprite_Proxy postProxy5 = new Sprite_Proxy(postSprite, 300, 5, fencePostScale, Color.White);
            ////////////////


            // Right Wall ///////////
            Sprite_Proxy postProxy6 = new Sprite_Proxy(postSprite, 300, 95, fencePostScale, Color.White);

            ///////////////////////

            // Left Wall /////////
            Sprite_Proxy postProxy7 = new Sprite_Proxy(postSprite, 5, 95, fencePostScale, Color.White);

            // Bottom Wall ////////
            Sprite_Proxy postProxy8 = new Sprite_Proxy(postSprite, 5, 190, fencePostScale, Color.White);
            Sprite_Proxy postProxy9 = new Sprite_Proxy(postSprite, 75, 190, fencePostScale, Color.White);
            Sprite_Proxy postProxy10 = new Sprite_Proxy(postSprite, 150, 190, fencePostScale, Color.White);
            Sprite_Proxy postProxy11 = new Sprite_Proxy(postSprite, 225, 190, fencePostScale, Color.White);
            Sprite_Proxy postProxy12 = new Sprite_Proxy(postSprite, 300, 190, fencePostScale, Color.White);
            //////////////


            // Center Posts ///
            Sprite_Proxy postProxy13 = new Sprite_Proxy(postSprite, 75, 71, fencePostScale, Color.White);
            Sprite_Proxy postProxy14 = new Sprite_Proxy(postSprite, 225, 71, fencePostScale, Color.White);
            Sprite_Proxy postProxy15 = new Sprite_Proxy(postSprite, 75, 119, fencePostScale, Color.White);
            Sprite_Proxy postProxy16 = new Sprite_Proxy(postSprite, 225, 119, fencePostScale, Color.White);
            ///////////////


            SBNode postBatch = SpriteBatchManager.Instance().getBatch(batchEnum.boxs);
            postBatch.addDisplayObject(postProxy1);
            postBatch.addDisplayObject(postProxy2);
            postBatch.addDisplayObject(postProxy3);
            postBatch.addDisplayObject(postProxy4);
            postBatch.addDisplayObject(postProxy5);
            postBatch.addDisplayObject(postProxy6);
            postBatch.addDisplayObject(postProxy7);
            postBatch.addDisplayObject(postProxy8);
            postBatch.addDisplayObject(postProxy9);
            postBatch.addDisplayObject(postProxy10);
            postBatch.addDisplayObject(postProxy11);
            postBatch.addDisplayObject(postProxy12);
            postBatch.addDisplayObject(postProxy13);
            postBatch.addDisplayObject(postProxy14);
            postBatch.addDisplayObject(postProxy15);
            postBatch.addDisplayObject(postProxy16);
        }


        

        
    }
}
