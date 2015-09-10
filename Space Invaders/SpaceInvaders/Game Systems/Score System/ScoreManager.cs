using System;

namespace SpaceInvaders
{
    class ScoreManager
    {
        private static ScoreManager smInstance = null;

        private Random rand;
        private int hiScore;

        private ScoreManager()
        {
            rand = new Random();
            hiScore = 0;
        }

        public static void killedSquid()
        {
            PlayerManager.getCurrentPlayer().Score += 30;
        }

        public static void killedCrab()
        {
            PlayerManager.getCurrentPlayer().Score += 20;
        }

        public static void killedOctopus()
        {
            PlayerManager.getCurrentPlayer().Score += 10;
        }

        public static void killedUFO()
        {
            int randVal = Instance.rand.Next(0, 15);
            int value;

            if (randVal < 5)
            {
                value = 50;
            }
            else if (randVal >= 5 && randVal < 10)
            {
                value = 100;
            }
            else
            {
                value = 150;
            }

            PlayerManager.getCurrentPlayer().Score += value;
        }

        private static ScoreManager Instance
        {
            get
            {
                if (smInstance == null)
                {
                    smInstance = new ScoreManager();
                }

                return smInstance;
            }
        }

        public static int HiScore
        {
            get
            {
                return Instance.hiScore;
            }
            set
            {
                Instance.hiScore = value;
            }
        }
    }
}
