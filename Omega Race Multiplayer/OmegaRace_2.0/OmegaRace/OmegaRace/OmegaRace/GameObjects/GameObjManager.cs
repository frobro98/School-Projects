using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpriteAnimation;
using Box2D.XNA;
using OmegaRace;

namespace CollisionManager
{
    enum GameObjType
    {
        //gameObj,
        p1missiles,   // can only collide once
        p2missiles,   // can only collide once
        p1ship,
        p2ship,
        horzWalls,
        vertWalls,
        bomb,
        fencePost,
        DESTROY,
        explosion,
        p1Bomb,
        p2Bomb,
        None
    }

    class GameObjManager : Manager
    {

        private static GameObjManager instance;

        private BodyNode destroyHead;
        private int objNumberCounter;


        private GameObjManager()
        {
            destroyHead = null;
            objNumberCounter = 0;
        }

        public static GameObjManager Instance()
        {
            if (instance == null)
                instance = new GameObjManager();
            return instance;
        }

        // For Linked List
        public void addGameObj(GameObject _obj)
        {

            GameObjNode node = new GameObjNode();
            _obj.setIndexNum(objNumberCounter++);
            node.Set(_obj);

            this.privActiveAddToFront((ManLink)node, ref this.active);
        }

        public void Update(World w)
        {
            ManLink ptr = this.active;

            GameObjNode gameObjNode = null;

            while (ptr != null)
            {
                gameObjNode = (GameObjNode)ptr;

                gameObjNode.gameObj.Update();

                ptr = ptr.next;
            }


            destroyBodies(w);
        }


        public void remove(batchEnum _enum, GameObject _obj)
        {
            GameObjNode node = findGameObj(_obj);

            if (node != null)
            {
                if (node.prev != null)
                {	// middle or last node
                    node.prev.next = node.next;
                }
                else
                {  // first
                    this.active = node.next;
                }

                if (node.next != null)
                {	// middle node
                    node.next.prev = node.prev;
                }

                addBodyToDestroy(_obj.physicsObj.body);

                if (_obj.spriteRef != null)
                {
                    SBNode SBNode = SpriteBatchManager.Instance().getBatch(_enum);
                    SBNode.removeDisplayObject(_obj.spriteRef);
                }

                if (_obj.physicsObj != null)
                {
                    PhysicsMan.Instance().removePhysicsObj(_obj.physicsObj);
                }
            }
        }

        public GameObject find(GameObjType type)
        {
            ManLink mLink = this.active;

            while (mLink != null)
            {
                if (mLink.getName().Equals(type))
                {
                    break;
                }

                mLink = mLink.next;
            }

            if (mLink != null)
                return ((GameObjNode)mLink).gameObj;
            else
                return null;
        }

        public GameObject findFromIndex(int uniqueNum)
        {
            ManLink mLink = this.active;

            while (mLink != null)
            {
                GameObject go = ((GameObjNode)mLink).gameObj;
                if (go.getIndexNum().Equals(uniqueNum))
                {
                    break;
                }

                mLink = mLink.next;
            }

            if (mLink != null)
                return ((GameObjNode)mLink).gameObj;
            else
                return null;
        }

        private GameObjNode findGameObj(GameObject _obj)
        {
            ManLink ptr = this.active;

            ManLink outNode = null;

            while (ptr != null)
            {
                if ((ptr as GameObjNode).gameObj.Equals(_obj))
                {
                    outNode = ptr;
                    break;
                }
                ptr = ptr.next;
            }

            return (outNode as GameObjNode);

        }

        public void addBodyToDestroy(Body b)
        {

            BodyNode bodyNode = new BodyNode(b);

            if (destroyHead == null)
            {
                destroyHead = bodyNode;
                bodyNode.next = null;
                bodyNode.prev = null;
            }
            else
            {
                bodyNode.next = destroyHead;
                destroyHead.prev = bodyNode;
                destroyHead = bodyNode;
            }
        }


        public void destroyBodies(World w)
        {
            BodyNode ptr = destroyHead;

            while (ptr != null)
            {
                w.DestroyBody(ptr.body);

                ptr = ptr.next;
            }

            destroyHead = null;

        }

        public void createBomb(PlayerID _id)
        {
            if (BombManager.Instance().bombAvailable(PlayerID.one))
            {
                Player player = PlayerManager.Instance().getPlayer(_id);

                player.removeBombSprite();

                Ship pShip = player.playerShip;
                Body pShipBody = pShip.physicsObj.body;

                Bomb bomb;

                if (_id == PlayerID.one)
                    bomb = new Bomb(GameObjType.p1Bomb, _id, pShip);
                else
                    bomb = new Bomb(GameObjType.p2Bomb, _id, pShip);
            }
        }

        


        public void addExplosion(Vector2 _pos, Color _color)
        {

            Sprite expSprite = (Sprite)DisplayManager.Instance().getDisplayObj(SpriteEnum.Explosion);
            Sprite_Proxy expProxy = new Sprite_Proxy(expSprite, (int)_pos.X, (int)_pos.Y, 0.20f, _color);

            SBNode expBatch = SpriteBatchManager.Instance().getBatch(batchEnum.explosions);
            expBatch.addDisplayObject(expProxy);

            TimeSpan currentTime = Timer.GetCurrentTime();
            TimeSpan t_1 = currentTime.Add(new TimeSpan(0, 0, 0, 0, 500));
            CallBackData nodeData = new CallBackData(3, TimeSpan.Zero);
            nodeData.spriteRef = expProxy;

            Timer.Add(t_1, nodeData, removeExplosion);


        }

        public void removeExplosion(object obj)
        {
            CallBackData nodeData = (CallBackData)obj;

            SBNode sbNode = SpriteBatchManager.Instance().getBatch(batchEnum.explosions);
            sbNode.removeDisplayObject(nodeData.spriteRef);
        }

        protected override object privGetNewObj()
        {
            throw new NotImplementedException();
        }
        

       

        public void clear()
        {
            this.active = null;
            instance = null;
        }

        

    }
}
