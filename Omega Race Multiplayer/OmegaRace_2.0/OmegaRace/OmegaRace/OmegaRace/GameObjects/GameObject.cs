using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Box2D.XNA;
using OmegaRace;

namespace CollisionManager
{

    enum GameObjState
    {
        alive,
        dead
    }

    abstract class GameObject : Visitor
    {
        public Sprite_Proxy spriteRef;

        public GameObjType type;
        public int indexNum;
        public bool CollideAvailable;

        public PhysicsObj physicsObj;

        // Speed is m/s 
        // Note the max speed of any object is 120m/s  /////////
        public static float MaxSpeed = 50;

        public Vector2 objSpeed;

        public float rotation;
        public Vector2 location;

        public GameObject()
        {
            rotation = 0;
            location = new Vector2();
            this.CollideAvailable = true;
        }

        public void setIndexNum(int index)
        {
            this.indexNum = index;
        }

        public int getIndexNum()
        {
            return this.indexNum;
        }

        public virtual void Update()
        {
            this.spriteRef.pos = location;
            this.spriteRef.rotation = rotation;
        }

        abstract public void doWork(LocationHdr hdr);

        public void setPhysicsObj(PhysicsObj _physObj)
        {
            physicsObj = _physObj;
        }

        public void pushPhysics(float rot, Vector2 loc, GameObjType type)
        {
            GameObjType goType = type;

            LocationHdr hdr;
            hdr.goIndex = this.indexNum;
            hdr.position = loc;
            hdr.rotation = rot;
            
            hdr.networked = false;

            OutputQueue.pushHeader(ref hdr);
            //rotation = rot;
            //location = loc;
        }
       

    }
}
