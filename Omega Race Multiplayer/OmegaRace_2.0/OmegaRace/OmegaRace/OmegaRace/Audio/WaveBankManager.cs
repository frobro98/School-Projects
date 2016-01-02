using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework.Audio;

namespace CollisionManager
{

    enum waveBankEnum
    {
        waveBank1,
        none

    }

    class WaveBankManager
    {
        private static WaveBankManager instance;


        private static WaveBank waveBank = new WaveBank(AudioEngineManager.Instance().getEngine(), @"Content\WaveBnk.xwb");
        public static WaveBank WaveBank()
        {
            return waveBank;
        }

        private WaveBankManager()
        {

        }

        public static WaveBankManager Instance()
        {
            if (instance == null)
                instance = new WaveBankManager();
            return instance;
        }

    }
}
