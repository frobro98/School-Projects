using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Squid : Alien
    {
        public enum SquidName
        {
            Squid
        }

        public Squid(GameObject.Name goName, SpriteEnum sName, Index index, float x, float y)
            : base(goName, sName, index, x, y)
        {
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

        public override Index getIndex()
        {
            return this.index;
        }

    }
}
