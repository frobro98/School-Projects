using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Crab : Alien
    {

        public enum CrabName
        {
            Crab
        }

        public Crab(GameObject.Name goName, Index index, SpriteEnum sName, float x, float y)
            : base(goName, sName, index, x, y)
        {
            //colObj.Bounds = this.sprite.

        }

        public override void update()
        {
            this.sprite.setPos(this.x, this.y);
            this.colObj.setRectPos(this.x, this.y);
            this.colObj.update();
        }

        public override void draw()
        {
            this.sprite.draw();
        }

        public override Enum getName()
        {
            return this.name;
        }

    }
}
