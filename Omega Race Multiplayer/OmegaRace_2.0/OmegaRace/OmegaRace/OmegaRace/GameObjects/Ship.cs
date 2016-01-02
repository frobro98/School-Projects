using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Box2D.XNA;
using OmegaRace;

namespace CollisionManager
{
    


    class Ship: GameObject
    {

        WaveBank waveBank;
        SoundBank soundBank;

        public Ship(GameObjType _type, Sprite_Proxy _spriteRef)
        {
            type = _type;
            spriteRef = _spriteRef;

            
            waveBank = WaveBankManager.WaveBank();
            soundBank = SoundBankManager.SoundBank();


        }

        public override void doWork(LocationHdr hdr)
        {
            this.location = hdr.position;
            this.rotation = hdr.rotation;
        }

        public override void Update()
        {
            Vector2 velocity = physicsObj.body.GetLinearVelocity();
            if (velocity.Length() > MaxSpeed)
                physicsObj.body.SetLinearVelocity((MaxSpeed / velocity.Length() * velocity));

            base.Update();
        }

        public override void Accept(GameObject other, Vector2 _point)
        {
            other.VisitShip(this, _point);
        }

        public override void VisitMissile(Missile m, Vector2 _point)
        {
            reactionToShip(this, m, _point);
        }

        public override void VisitBomb(Bomb b, Vector2 _point)
        {
            reactionToShip(this, b, _point);
        }

        public override void VisitWall(Wall w, Vector2 _point)
        {
            w.hit();
        }

        private void reactionToShip(Ship s, Missile m, Vector2 _point)
        {

            if (s.type == GameObjType.p1ship && m.type == GameObjType.p2missiles)
            {

                GameObjManager.Instance().addExplosion(s.spriteRef.pos, s.spriteRef.color);
                GameObjManager.Instance().remove(batchEnum.ships, s);
                GameObjManager.Instance().remove(batchEnum.missiles, m);

                hit(PlayerID.one);

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

                hit(PlayerID.two);

                ScoreManager.Instance().p1Kill();

                playMissileHitSound();
                playShipHitSound();

                PlayerManager.Instance().getPlayer(m.owner).increaseNumMissiles();
            }
            else { }

            
            
        }

        private void reactionToShip(Ship s, Bomb b, Vector2 _point)
        {

            if (s.type == GameObjType.p1ship)
            {
                GameObjManager.Instance().remove(batchEnum.ships, s);
                BombManager.Instance().removeBomb(b, s.spriteRef.pos, s.spriteRef.color);

                hit(PlayerID.one);

                ScoreManager.Instance().p2Kill();

                playShipHitSound();
                playBombHitSound();
            }

            else if (s.type == GameObjType.p2ship)
            {
                GameObjManager.Instance().remove(batchEnum.ships, s);
                BombManager.Instance().removeBomb(b, s.spriteRef.pos, s.spriteRef.color);

                hit(PlayerID.two);

                ScoreManager.Instance().p1Kill();

                playShipHitSound();
                playBombHitSound();
            }
            else { }

            playShipHitSound();
        }

        public void hit(PlayerID _id)
        {
            PlayerManager.Instance().getPlayer(_id).state = PlayerState.dead;

            TimeSpan currentTime = Timer.GetCurrentTime();
            TimeSpan t_1 = currentTime.Add(new TimeSpan(0, 0, 0, 0, 600));
            CallBackData nodeData = new CallBackData(3, TimeSpan.Zero);
            nodeData.playerID = _id;

            Timer.Add(t_1, nodeData, PlayerManager.Instance().respawn);
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

        private void playBombHitSound()
        {
            Cue hit_Cue = soundBank.GetCue("Mine_Pop_Cue");
            hit_Cue.Play();
        }

    }
}
