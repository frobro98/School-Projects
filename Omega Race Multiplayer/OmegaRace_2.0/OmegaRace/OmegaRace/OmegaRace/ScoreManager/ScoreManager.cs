using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;

namespace CollisionManager
{
    class ScoreManager
    {

        private static ScoreManager instance;

        private TextSprite player1KillsText;
        private TextSprite player2KillsText;
        private TextSprite player1DeathsText;
        private TextSprite player2DeathsText;
        private TextSprite WinsText;
        private TextSprite versionNum;
        private TextSprite courseName;

        private int p1Kills;
        private int p1Deaths;
        private int p2Kills;
        private int p2Deaths;
        
        private int p1Wins;
        private int p2Wins;

        private ScoreManager()
        {
            createData();

            p1Kills = 0;
            p1Deaths = 0;
            p2Kills = 0;
            p2Deaths = 0;

            p1Wins = 0;
            p2Wins = 0;
        }

        public static ScoreManager Instance()
        {
            if (instance == null)
                instance = new ScoreManager();
            return instance;
        }


        public void Update()
        {
            player1KillsText.message = "Kills: " + p1Kills;
            player1DeathsText.message = "Deaths: " + p1Deaths;

            player2KillsText.message = p2Kills + " :Kills";
            player2DeathsText.message = p2Deaths + " :Deaths";

            WinsText.message = p1Wins + ":" + p2Wins;
        }

        public void createData()
        {
            player1KillsText = (TextSprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p1KillsText);
            player1DeathsText = (TextSprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p1DeathsText);

            player2KillsText = (TextSprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p2KillsText);
            player2DeathsText = (TextSprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.p2DeathsText);

            WinsText = (TextSprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.Wins);


            versionNum = (TextSprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.versionNum);
            courseName = (TextSprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.courseNum);

            versionNum.message = "v2.0";
            courseName.message = "";

            SBNode titleBatch = SpriteBatchManager.Instance().getBatch(batchEnum.displayText);
            titleBatch.addDisplayObject(player1KillsText);
            titleBatch.addDisplayObject(player1DeathsText);
            titleBatch.addDisplayObject(player2KillsText);
            titleBatch.addDisplayObject(player2DeathsText);
            titleBatch.addDisplayObject(WinsText);
            titleBatch.addDisplayObject(versionNum);
            titleBatch.addDisplayObject(courseName);
            
        }


        public void clear()
        {
            instance = null;
        }

        public void p1Kill()
        {
            p1Kills++;
            p2Deaths++;
        }

        public void p2Kill()
        {
            p2Kills++;
            p1Deaths++;
        }

        public void p1Win()
        {
            p1Wins++;
        }

        public void p2Win()
        {
            p2Wins++;
        }
    }
}
