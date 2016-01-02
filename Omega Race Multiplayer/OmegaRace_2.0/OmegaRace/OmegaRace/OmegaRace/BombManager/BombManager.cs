using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using CollisionManager;
using Microsoft.Xna.Framework.Audio;
using Box2D.XNA;
using Microsoft.Xna.Framework;

namespace OmegaRace
{

    class BombManager
    {
        private static BombManager instance;

        Sprite[] p1BombTable;
        Sprite[] p2BombTable;

        int p1Ptr;
        int p2Ptr;

        WaveBank waveBank;
        SoundBank soundBank;

        private BombManager()
        {
            p1BombTable = new Sprite[5];
            p2BombTable = new Sprite[5];

            p1Ptr = 0;
            p2Ptr = 0;

            soundBank = SoundBankManager.SoundBank();
            waveBank = WaveBankManager.WaveBank();

            loadTables();
        }

        public static BombManager Instance()
        {
            if (instance == null)
                instance = new BombManager();
            return instance;
        }

        private void loadTables()
        {
            p1BombTable[0] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p1Bomb1);
            p1BombTable[1] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p1Bomb2);
            p1BombTable[2] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p1Bomb3);
            p1BombTable[3] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p1Bomb4);
            p1BombTable[4] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p1Bomb5);


            p2BombTable[0] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p2Bomb1);
            p2BombTable[1] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p2Bomb2);
            p2BombTable[2] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p2Bomb3);
            p2BombTable[3] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p2Bomb4);
            p2BombTable[4] = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p2Bomb5);
            
        }

        public BombData getNextBomb(PlayerID _id)
        {
            BombData outData = new BombData();

            if (_id == PlayerID.one)
                outData = getP1BombSprite();
            else
                outData = getP2BombSprite();

            return outData;
        }

        private BombData getP1BombSprite()
        {
            BombData outData = new BombData();

            for (int i = 0; i < 5; i++)
            {
                if (p1BombTable[i] != null)
                {
                    outData.sprite = p1BombTable[i];
                    outData.ID = i;
                    p1BombTable[i] = null;
                    p1Ptr++;
                    break;
                }
            }

            

            return outData;
        }

        private BombData getP2BombSprite()
        {
            BombData outData = new BombData();

            for (int i = 0; i < 5; i++)
            {
                if (p2BombTable[i] != null)
                {
                    outData.sprite = p2BombTable[i];
                    outData.ID = i;
                    p2BombTable[i] = null;
                    p2Ptr++;
                    break;
                }
            }

            return outData;
        }

        public bool bombAvailable(PlayerID _id)
        {
            if (_id == PlayerID.one)
            {
                if (p1Ptr >= 5)
                    return false;
                else
                    return true;
            }
            else
            {
                if (p2Ptr >= 5)
                    return false;
                else
                    return true;

            }

        }

        private void addBomb(Bomb b)
        {
            if (b.owner == PlayerID.one)
            {
                p1BombTable[b.bombID] = b.bombsprite;
                p1Ptr--;
            }
            else
            {
                p2BombTable[b.bombID] = b.bombsprite;
                p2Ptr--;
            }
        }

        public void removeBomb(Bomb b, Vector2 _pos, Color _color)
        {
            if (b.state == BombState.alive)
            {
                b.state = BombState.dead;

                b.spriteRef.sprite.image = b.image1;

                GameObjManager.Instance().addExplosion(_pos, _color);

                GameObjManager.Instance().remove(batchEnum.bomb, b);

                BombManager.Instance().addBomb(b);

                playBombHitSound();

                PlayerManager.Instance().getPlayer(b.owner).addBombSprite();
            }
        }

        public void removeBomb(Bomb b)
        {
            if (b.state == BombState.alive)
            {
                b.state = BombState.dead;

                b.spriteRef.sprite.image = b.image1;

                GameObjManager.Instance().remove(batchEnum.bomb, b);

                BombManager.Instance().addBomb(b);

                playBombHitSound();

                PlayerManager.Instance().getPlayer(b.owner).addBombSprite();
            }
        }

        private void playBombHitSound()
        {
            Cue hit_Cue = soundBank.GetCue("Mine_Pop_Cue");
            hit_Cue.Play();
        }

        public void clear()
        {
            instance = null;
        }
    }
}
