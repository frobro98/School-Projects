using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class SpawnUFO : Command
    {
        public SpawnUFO()
        {

        }

        public override void execute(float time)
        {
            Random rand = new Random();
            int side = rand.Next(0,2);
            if(side < 1)
            {
                UFOFactory.create(UFO.Side.Right);
            }
            else
            {
                UFOFactory.create(UFO.Side.Left);
            }

            SoundManager.playUFO();
        }
    }
}
