using System;

namespace SpaceInvaders
{
    class SpawnBomb : Command
    {
        GameObject alienTree;
        GameObject.Name name;
        Index index;

        public SpawnBomb()
        {
            name = GameObject.Name.Not_Initialized;
            index = Index.Index_Null;
            alienTree = null;
        }

        public SpawnBomb(GameObject.Name obj, Index index = Index.Index_Null)
        {
            name = obj;
            this.index = index;
            alienTree = GameObjectManager.find(name, index);
        }

        public override void execute(float time)
        {
            Random rand = new Random();
            int row = rand.Next(0, 11);
            GameObject column = (GameObject)alienTree.Child;

            if (column != null)
            {
                int i = 0;
                while (column.Sibling != null && i < row)
                {
                    i++;
                    column = (GameObject)column.Sibling;
                }

                GameObject lowestAlien = (GameObject)column.Child;
                int bomb = rand.Next(0, 3);
                if (bomb == 0)
                {
                    BombFactory.create(Bomb.LineType.Line, lowestAlien.getX(), lowestAlien.getY());
                }
                else if (bomb == 1)
                {
                    BombFactory.create(Bomb.ZigZagType.ZigZag, lowestAlien.getX(), lowestAlien.getY());
                }
                else if (bomb == 2)
                {
                    BombFactory.create(Bomb.CrossType.Cross, lowestAlien.getX(), lowestAlien.getY());
                }

                // Change to a difficulty setting
                float newTime = (float)rand.Next(3, 5);
                TimeEventManager.add(newTime, this, TimeEvent.EventType.BombSpawn);
            }
        }
    }
}
