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
    class Missile : GameObject
    {
        SoundBank soundBank;
        WaveBank waveBank;

        public PlayerID owner;
        

        public Missile(GameObjType _type, Sprite_Proxy _spriteRef, PlayerID _owner)
        {
            type = _type;

            spriteRef = _spriteRef;

            objSpeed = new Vector2(0, -15);

            soundBank = SoundBankManager.SoundBank();
            waveBank = WaveBankManager.WaveBank();

            owner = _owner;

            playFireSound();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void doWork(LocationHdr hdr)
        {
            this.rotation = hdr.rotation;
            this.location = hdr.position;
        }

        public override void Accept(GameObject other, Vector2 _point)
        {
            other.VisitMissile(this, _point);
        }

        public override void VisitWall(Wall w, Vector2 _point)
        {
            reactionToMissile(this, w, _point);
        }

        public override void VisitShip(Ship s, Vector2 _point)
        {
            reactionToMissile(this, s, _point);
        }

        public override void VisitMissile(Missile m, Vector2 _point)
        {
            reactionToMissile(this, m, _point);
        }

        public override void VisitBomb(Bomb b, Vector2 _point)
        {
            reactionToMissile(this, b, _point);
        }

        private void reactionToMissile(Missile m, Bomb b, Vector2 _point)
        {
            BombManager.Instance().removeBomb(b, b.spriteRef.pos, b.spriteRef.color);
            GameObjManager.Instance().remove(batchEnum.missiles, m);

            PlayerManager.Instance().getPlayer(m.owner).increaseNumMissiles();

            playMissileHitSound();
        }

        private void reactionToMissile(Missile m, Wall w, Vector2 _point)
        {
            //Vector2 pos = m.physicsObj.body.GetWorldPoint(_man.LocalPoint);
            Vector2 pos = _point;

            GameObjManager.Instance().addExplosion(pos, m.spriteRef.color);
            GameObjManager.Instance().remove(batchEnum.missiles, m);

            PlayerManager.Instance().getPlayer(m.owner).increaseNumMissiles();

            playMissileHitSound();

            w.hit();
        }

        private void reactionToMissile(Missile m1, Missile m2, Vector2 _point)
        {
            // Vector2 pos = m1.physicsObj.body.GetWorldPoint(_man.LocalPoint);
            if (m1.owner != m2.owner)
            {
                Vector2 pos = _point;

                GameObjManager.Instance().addExplosion(pos, m1.spriteRef.color);
                GameObjManager.Instance().remove(batchEnum.missiles, m1);
                GameObjManager.Instance().remove(batchEnum.missiles, m2);

                PlayerManager.Instance().getPlayer(m1.owner).increaseNumMissiles();
                PlayerManager.Instance().getPlayer(m2.owner).increaseNumMissiles();

                playMissileHitSound();
            }
        }

        private void reactionToMissile(Missile m, Ship s, Vector2 _point)
        {

            if (s.type == GameObjType.p1ship && m.type == GameObjType.p2missiles)
            {

                GameObjManager.Instance().addExplosion(s.spriteRef.pos, s.spriteRef.color);
                GameObjManager.Instance().remove(batchEnum.ships, s);
                GameObjManager.Instance().remove(batchEnum.missiles, m);

                s.hit(PlayerID.one);

                ScoreManager.Instance().p2Kill();
                
                playMissileHitSound();
                playShipHitSound();

                PlayerManager.Instance().getPlayer(m.owner).increaseNumMissiles();

            }

            else if (s.type == GameObjType.p2ship && m.type == GameObjType.p1missiles)
            {

                GameObjManager.Instance().addExplosion(s.spriteRef.pos, s.spriteRef.color);
                GameObjManager.Instance().remove(batchEnum.ships, s);
                GameObjManager.Instance().remove(batchEnum.missiles, m);

                s.hit(PlayerID.two);

                ScoreManager.Instance().p1Kill();

                playMissileHitSound();
                playShipHitSound();

                PlayerManager.Instance().getPlayer(m.owner).increaseNumMissiles();
            }
            else { }
            
        }


        private void playFireSound()
        {
            Cue fire_Cue = soundBank.GetCue("Fire_Cue");
            fire_Cue.Play();
        }

        private void playMissileHitSound()
        {
            Cue hit_Cue = soundBank.GetCue("Laser_Hit_Cue");
            hit_Cue.Play();
        }

        private void playShipHitSound()
        {
            Cue hit_Cue = soundBank.GetCue("Ship_Pop_Cue");
            hit_Cue.Play();
        }

    }
}
