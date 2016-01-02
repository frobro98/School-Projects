using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Box2D.XNA;
using CollisionManager;
using Microsoft.Xna.Framework;

namespace OmegaRace
{
    enum ColShip
    {
        Ship
    }

    enum ColWall
    {
        Wall
    }

    enum ColMissile
    {
        Missile
    }

    enum ColMine
    {
        Mine
    }

    class myContactListener : IContactListener
    {



        public  void BeginContact(Contact contact)
        {
            GameObject A = (GameObject)contact.GetFixtureA().GetUserData();
            GameObject B = (GameObject)contact.GetFixtureB().GetUserData();

            Manifold manifold;
            Transform xfA;
            Transform xfB;
            float radiusA;
            float radiusB;

            contact.GetFixtureA().GetBody().GetTransform(out xfA);
            contact.GetFixtureB().GetBody().GetTransform(out xfB);
            radiusA = contact.GetFixtureA().GetShape()._radius;
            radiusB = contact.GetFixtureB().GetShape()._radius;

            contact.GetManifold(out manifold);

            WorldManifold worldManifold = new WorldManifold(ref manifold,ref xfA,radiusA,ref xfB,radiusB);

            Vector2 ptA = worldManifold._points[0];
            Vector2 ptB = worldManifold._points[1];

            //System.Console.Write(" point {0} {1}\n", ptA, ptB);

            ColHdr cHdr;
            cHdr.goID1 = A.getIndexNum();
            cHdr.goID2 = B.getIndexNum();
            cHdr.pos = ptA;

            InputHdr iHdr;
            iHdr.colInfo = cHdr;
            iHdr.input = InputType.Collision;
            iHdr.player = PlayerID.none;
            iHdr.networked = false;

            OutputQueue.pushHeader(iHdr);

            //if (A.CollideAvailable == true && B.CollideAvailable == true)
            //{
            //    if (A.type < B.type)
            //    {
            //        A.Accept(B, ptA);
            //    }
            //    else
            //    {
            //        B.Accept(A, ptA);
            //    }
            //}

            //if (A.type == GameObjType.p1missiles || A.type == GameObjType.p2missiles)
            //{
            //    A.CollideAvailable = false;
            //}

            //if (B.type == GameObjType.p1missiles || B.type == GameObjType.p2missiles)
            //{
            //    B.CollideAvailable = false;
            //}
        }

        public  void EndContact(Contact contact)
        {
            
        }

        public void PostSolve(Contact contact, ref ContactImpulse impulse)
        {
        }

        public void PreSolve(Contact contact, ref Manifold oldManifold)
        {
        }

        


    }
}
