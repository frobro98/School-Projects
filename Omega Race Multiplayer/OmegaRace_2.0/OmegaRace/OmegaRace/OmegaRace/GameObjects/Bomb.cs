using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Box2D.XNA;
using OmegaRace;

namespace CollisionManager
{
    enum BombState
    {
        alive,
        dead
    }



    struct BombData
    {
        public Sprite sprite;
        public int ID;
    }




    class Bomb : GameObject
    {

        SoundBank soundBank;
        WaveBank waveBank;

        Vector2 orgPos;
        int curImage;

        public PlayerID owner;
        public Image image1;
        public Image image2;
        public Sprite bombsprite;
        public int bombID;
        public BombState state;



        public Bomb(GameObjType _type, PlayerID _owner, Ship s)
        {
            type = _type;

            createBomb(_owner, s);

            owner = _owner;

            soundBank = SoundBankManager.SoundBank();
            waveBank = WaveBankManager.WaveBank();

            playBombLaySound();

            armBomb();
        }

        public override void doWork(LocationHdr hdr)
        {
            this.location = hdr.position;
            this.rotation = hdr.rotation;
        }

        public override void Update()
        {
            base.Update();
        }


        public override void Accept(GameObject other, Vector2 _point)
        {
            other.VisitBomb(this, _point);
        }

        public override void VisitMissile(Missile m, Vector2 _point)
        {
            reactionToBomb(m, this, _point);
        }

        public override void VisitShip(Ship s, Vector2 _point)
        {
            reactionToBomb(s, this, _point);
        }

        public override void VisitBomb(Bomb b, Vector2 _point)
        {
        }

        private void reactionToBomb(Missile m, Bomb b, Vector2 _point)
        {
            BombManager.Instance().removeBomb(b, b.spriteRef.pos, b.spriteRef.color);

            GameObjManager.Instance().remove(batchEnum.missiles, m);

            PlayerManager.Instance().getPlayer(m.owner).increaseNumMissiles();
        }


        private void reactionToBomb(Ship s, Bomb b, Vector2 _point)
        {
            if (s.type == GameObjType.p1ship)
            {
                GameObjManager.Instance().remove(batchEnum.ships, s);
                BombManager.Instance().removeBomb(b, s.spriteRef.pos, s.spriteRef.color);

                s.hit(PlayerID.one);

                ScoreManager.Instance().p2Kill();

                playShipHitSound();
            }

            else if (s.type == GameObjType.p2ship)
            {
                GameObjManager.Instance().remove(batchEnum.ships, s);
                BombManager.Instance().removeBomb(b, s.spriteRef.pos, s.spriteRef.color);

                s.hit(PlayerID.two);

                ScoreManager.Instance().p1Kill();

                playShipHitSound();
            }
            else { }
        }

        

        private void armBomb()
        {
            TimeSpan currentTime = Timer.GetCurrentTime();
            TimeSpan t_1 = currentTime.Add(new TimeSpan(0, 0, 0, 2, 0));
            CallBackData nodeData = new CallBackData(0, Timer.GetCurrentTime());

            Timer.Add(t_1, nodeData, armed);
        }

        private void armed(object obj)
        {

            World world = Game1.GameInstance.getWorld();

            Ship ship = PlayerManager.Instance().getPlayer(owner).playerShip;
            Body shipBody = ship.physicsObj.body;


            var bombShape = new PolygonShape();

            bombShape.SetAsBox(5, 5);

            var fd = new FixtureDef();
            fd.shape = bombShape;
            fd.restitution = 0.0f;
            fd.friction = 0.0f;
            fd.density = 0.0001f;
            fd.userData = this;


            BodyDef bd = new BodyDef();
            bd.fixedRotation = true;

            bd.type = BodyType.Static;
            bd.position = orgPos;

            var body = world.CreateBody(bd);
            body.CreateFixture(fd);
            body.SetUserData(this);


            TimeSpan currentTime = Timer.GetCurrentTime();
            TimeSpan t_1 = currentTime.Add(new TimeSpan(0, 0, 0, 0, 0));
            CallBackData nodeData = new CallBackData(0, Timer.GetCurrentTime());

            bombAnim(nodeData);

            GameObjManager.Instance().addGameObj(this);
            PhysicsMan.Instance().addPhysicsObj(this, body);

            playBombArmedSound();
        }

        private void bombAnim(object obj)
        {
            if (state == BombState.alive)
            {
                flipSprite();

                // local data for my call back (I call it monkey)
                CallBackData monoData = (CallBackData)obj;
                // get the current time
                TimeSpan totTime = Timer.GetCurrentTime() - monoData.deltaTime;

                if (totTime.TotalSeconds > 5)
                    BombManager.Instance().removeBomb(this);
                else
                {
                    // Update my target time for next TimeEvent
                    monoData.targetTime = Timer.GetCurrentTime() + new TimeSpan(0, 0, 0, 0, 300);
                    // just increment count to show off
                    monoData.count += 10;
                    // install next TimeEvent
                    Timer.Add(monoData.targetTime, obj, bombAnim);
                }
            }
            else
            {

            }
        }

        private void flipSprite()
        {
            if (curImage == 0)
            {
                curImage++;
                spriteRef.sprite.image = image2;
            }
            else
            {
                curImage = 0;
                spriteRef.sprite.image = image1;
            }
                
        }

        private void createBomb(PlayerID _id, Ship s)
        {
            BombData data = BombManager.Instance().getNextBomb(_id);

            bombID = data.ID;

            bombsprite = data.sprite;
            spriteRef = new Sprite_Proxy(bombsprite, (int)s.spriteRef.pos.X, (int)s.spriteRef.pos.Y, 0.5f, Color.White);

            SBNode bombBatch = SpriteBatchManager.Instance().getBatch(batchEnum.bomb);
            bombBatch.addDisplayObject(spriteRef);

            orgPos = spriteRef.pos;


            if (_id == PlayerID.one)
            {
                image1 = ImageManager.Instance().getImage(ImageEnum.bluebomb1);
                image2 = ImageManager.Instance().getImage(ImageEnum.bluebomb2);
            }
            else
            {
                image1 = ImageManager.Instance().getImage(ImageEnum.greenbomb1);
                image2 = ImageManager.Instance().getImage(ImageEnum.greenbomb2);
            }

            spriteRef.sprite.image = image1;

            curImage = 0;

            state = BombState.alive;

        }

        private void playShipHitSound()
        {
            Cue hit_Cue = soundBank.GetCue("Ship_Pop_Cue");
            hit_Cue.Play();
        }

        private void playBombLaySound()
        {
            Cue hit_Cue = soundBank.GetCue("Mine_Lay_Cue");
            hit_Cue.Play();
        }

        private void playBombArmedSound()
        {
            Cue hit_Cue = soundBank.GetCue("Mine_Arm_Cue");
            hit_Cue.Play();
        }
    }
}
