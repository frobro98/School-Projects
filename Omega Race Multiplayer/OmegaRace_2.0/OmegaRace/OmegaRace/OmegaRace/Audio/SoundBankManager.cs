using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework.Audio;

namespace CollisionManager
{
    enum soundBankEnum
    {
        soundBank1,
        none
    }

    class SoundBankManager
    {

        private static SoundBankManager instance;

        private static SoundBank soundBank = new SoundBank(AudioEngineManager.Instance().getEngine(), @"Content\SndBnk.xsb");
        public static SoundBank SoundBank()
        {
            return soundBank;
        }

        private SoundBankManager()
        {
        }

        public static SoundBankManager Instance()
        {
            if (instance == null)
                instance = new SoundBankManager();
            return instance;
        }
    }
}
