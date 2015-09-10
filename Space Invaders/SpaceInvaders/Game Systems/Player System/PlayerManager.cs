using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerManager
    {
        private static PlayerManager pmInstance = null;

        private int possibleHiScore;

        private Player player1;
        private Player player2;

        private Player currPlayer;

        private PlayerManager()
        {
            player1 = null;
            player2 = null;
            currPlayer = null;
            possibleHiScore = 0;
        }

        public static void endGame()
        {
            if (Instance.possibleHiScore > ScoreManager.HiScore)
            {
                ScoreManager.HiScore = Instance.possibleHiScore;
            }

            Instance.player1 = null;
            Instance.player2 = null;
        }

        public static void set1Player()
        {
            Instance.player1 = new Player();
            Instance.currPlayer = Instance.player1;
        }

        public static void set2Players()
        {
            Instance.player2 = new Player();
            Instance.player1 = new Player();
            Instance.currPlayer = Instance.player1;
        }

        public static Player getCurrentPlayer()
        {
            return Instance.currPlayer;
        }

        public static Player getPlayer1()
        {
            return Instance.player1;
        }

        public static Player getPlayer2()
        {
            return Instance.player2;
        }

        public static void changePlayer()
        {
            if (Instance.currPlayer == Instance.player1)
            {
                Instance.setToPlayer2();
            }
            else if (Instance.currPlayer == Instance.player2)
            {
                Instance.setToPlayer1();
            }
        }

        private void checkGameOver()
        {
            if (player1 == null && player2 == null)
            {

            }
        }

        private void setToPlayer1()
        {
            if (player1 != null && player1.Lives > 0)
            {
                currPlayer = player1;
                currPlayer.hookupManagers();
            }
            else
            {
                if (player1.Score > possibleHiScore)
                    possibleHiScore = player1.Score;
                player1 = null;
                checkGameOver();

            }
        }

        private void setToPlayer2()
        {
            if (player2 != null && player2.Lives > 0)
            {
                currPlayer = player2;
                currPlayer.hookupManagers();
            }
            else
            {
                if (player2.Score > possibleHiScore)
                    possibleHiScore = player2.Score;
                player2 = null;
                checkGameOver();
            }
        }

        public static PlayerManager Instance
        {
            get
            {
                if (pmInstance == null)
                {
                    pmInstance = new PlayerManager();
                }

                return pmInstance;
            }
        }


    }
}
