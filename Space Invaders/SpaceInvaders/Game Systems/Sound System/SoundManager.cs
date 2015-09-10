using System;

namespace SpaceInvaders
{
    class SoundManager
    {
        private string[] alienSndFiles;
        private int currFile;
        private static SoundManager smInstance = null;
        private Azul.Sound ufo;
        private bool resetingWave;
        

        private SoundManager()
        {
            alienSndFiles = new string[4]{"A.wav", "B.wav", "C.wav", "D.wav"};
            currFile = 1;
            Azul.Audio.setMasterVolume(10f);
            resetingWave = false;
        }

        public static void playMovement()
        {
            if (!Instance.resetingWave)
            {
                Azul.Audio.playSound(Instance.alienSndFiles[Instance.currFile], false, false, true);
                Instance.currFile = (++Instance.currFile) % 4;
            }
        }

        public static void stopMovement()
        {
             
        }

        public static void resetMovement()
        {
            Instance.resetingWave = false;
            Instance.currFile = 1;
        }

        public static void playUFO()
        {
            Instance.ufo = Azul.Audio.playSound("ufo_highpitch.wav", true, false, true);
        }

        public static void stopUFO()
        {
            Instance.ufo.Pause(true);
        }

        public static void playUFODeath()
        {
            Azul.Audio.playSound("ufo_lowpitch.wav", false, false, true);
        }

        public static void playMissile()
        {
            Azul.Audio.playSound("shoot.wav", false, false, true);
        }

        public static void playAlienDeath()
        {
            Azul.Audio.playSound("invaderkilled.wav", false, false, true);
        }

        private static SoundManager Instance
        {
            get
            {
                if (smInstance == null)
                {
                    smInstance = new SoundManager();
                }

                return smInstance;
            }
        }

        public static bool ResetingWave
        {
            set
            {
                Instance.resetingWave = value;
            }
        }

    }
}
