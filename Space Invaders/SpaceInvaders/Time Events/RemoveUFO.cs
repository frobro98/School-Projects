using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class RemoveUFO : Command
    {
        private UFO ufo;

        public RemoveUFO(UFO ufo)
        {
            this.ufo = ufo;
        }

        public override void execute(float time)
        {
            DestroyManager.attach(ufo);
            SoundManager.stopUFO();
        }
    }
}
