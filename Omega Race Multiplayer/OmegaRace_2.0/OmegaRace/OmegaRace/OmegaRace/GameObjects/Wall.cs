using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Box2D.XNA;
using OmegaRace;

namespace CollisionManager
{
    class Wall: GameObject
    {
        WaveBank waveBank;
        SoundBank soundBank;

        Animation anim;

        public Wall(GameObjType _type, Sprite_Proxy _spriteRef)
        {
            type = _type;
            spriteRef = _spriteRef;

            anim = new Animation(spriteRef.sprite);

            setUpAnimation();

            soundBank = SoundBankManager.SoundBank();
            waveBank = WaveBankManager.WaveBank();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void doWork(LocationHdr hdr)
        {
            this.location = hdr.position;
            this.rotation = hdr.rotation;
        }

        public override void Accept(GameObject other, Vector2 _point)
        {
            other.VisitWall(this, _point);
        }


        public override void VisitMissile(Missile m, Vector2 _point)
        {
            reactionToWall(this, m, _point);
        }

        public override void VisitShip(Ship s, Vector2 _point)
        {
            playFenceHit();
            hit();
        }

        private void reactionToWall(Wall w, Missile m, Vector2 _point)
        {
           // Vector2 pos = m.physicsObj.body.GetWorldPoint(_man.LocalPoint);
            Vector2 pos = _point;

            GameObjManager.Instance().addExplosion(pos, m.spriteRef.color);
            GameObjManager.Instance().remove(batchEnum.missiles, m);
            playFenceHit();

            PlayerManager.Instance().getPlayer(m.owner).increaseNumMissiles();

            hit();
        }

        private void playFenceHit()
        {
            Cue hit_Cue = soundBank.GetCue("Fence_Hit_Cue");
            hit_Cue.Play();
        }

        private void setUpAnimation()
        {
            anim.addImage(ImageManager.Instance().getImage(ImageEnum.fence2));
            anim.addImage(ImageManager.Instance().getImage(ImageEnum.fence3));
            anim.addImage(ImageManager.Instance().getImage(ImageEnum.fence4));
            anim.addImage(ImageManager.Instance().getImage(ImageEnum.fence5));
            anim.addImage(ImageManager.Instance().getImage(ImageEnum.fence6));
            anim.addImage(ImageManager.Instance().getImage(ImageEnum.fence7));

        }

        public void hit()
        {
            playFenceHit();

            CallBackData nodeData = new CallBackData(0, TimeSpan.Zero);

            playAnim(nodeData);
        }

        private void playAnim(object obj)
        {
            CallBackData data = (CallBackData)obj;


            if (data.count < 6)
            {
                anim.flipImage();

                TimeSpan currentTime = Timer.GetCurrentTime();
                TimeSpan t_1 = currentTime.Add(new TimeSpan(0, 0, 0, 0, 50));

                data.count++;

                Timer.Add(t_1, data, playAnim);

            }
        }
    }
}
