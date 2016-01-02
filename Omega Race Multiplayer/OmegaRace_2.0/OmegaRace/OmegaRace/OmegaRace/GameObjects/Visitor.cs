using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Box2D.XNA;
using Microsoft.Xna.Framework;

namespace CollisionManager
{
    abstract class Visitor
    {

        


        public virtual void Accept(GameObject _obj, Vector2 _point)
        {

        }

        public virtual void VisitShip(Ship s, Vector2 _point)
        {

        }

        public virtual void VisitWall(Wall w, Vector2 _point)
        {

        }

        public virtual void VisitMissile(Missile m, Vector2 _point)
        {

        }

        public virtual void VisitBomb(Bomb b, Vector2 _point)
        {

        }
    }
}
