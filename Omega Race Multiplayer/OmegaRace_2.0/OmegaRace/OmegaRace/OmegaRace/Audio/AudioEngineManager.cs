using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework.Audio;
using OmegaRace;

namespace CollisionManager
{
    enum audioEngineEnum
    {
        audioEngine1,
        none

    }

    class AudioEngineManager : Manager
    {
        private static AudioEngineManager instance;

        private AudioEngine engine;

        private AudioEngineManager()
        {
            createEngines();
        }

        public static AudioEngineManager Instance()
        {
            if (instance == null)
                instance = new AudioEngineManager();
            return instance;
        }


        private void createEngines()
        {
            engine = new AudioEngine(@"Content\Monkey.xgs");
        }

        public AudioEngine getEngine()
        {
            return engine;
        }

        protected override object privGetNewObj()
        {
            throw new NotImplementedException();
        }
    }
}
