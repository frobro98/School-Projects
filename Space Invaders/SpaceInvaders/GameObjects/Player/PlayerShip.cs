using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerShip : GameObject, Context
    {
        PlayerState[] states;
        PlayerState playerState;
        bool canMoveLeft;
        bool canMoveRight;
        bool spacePressed;

        public enum PlayerName
        {
            Player
        }

        public enum PlayerStates
        {
            Start,
            Ready,
            NoShoot
        }

        public PlayerShip()
            : base(Name.Player,SpriteEnum.Player, Index.Index_Null, new Azul.Color(0, 1.0f, 0), new Azul.Color(1.0f, 0.0f, 0.0f), 512, 35) 
        {
            sprite = new ProxySprite(SpriteEnum.Player, Index.Index_Null, x, y);
            canMoveLeft = true;
            canMoveRight = true;
            spacePressed = false;
            states = new PlayerState[3];

            PlayerState start = new StartState();
            PlayerState ready = new ReadyState();
            PlayerState noShoot = new NoShootState();
            states[(int)PlayerStates.Start] = start;
            states[(int)PlayerStates.Ready] = ready;
            states[(int)PlayerStates.NoShoot] = noShoot;
            playerState = ready;
        }

        public PlayerShip(float x, float y)
            : base(Name.Player, SpriteEnum.Player, Index.Index_Null, new Azul.Color(0, 1.0f, 0), new Azul.Color(0, 1, 0), x, y)
        {
            sprite = new ProxySprite(SpriteEnum.Player, Index.Index_Null, x, y);
            canMoveLeft = true;
            canMoveRight = true;
            states = new PlayerState[3];

            PlayerState start = new StartState();
            PlayerState ready = new ReadyState();
            PlayerState noShoot = new NoShootState();
            states[(int)PlayerStates.Start] = start;
            states[(int)PlayerStates.Ready] = ready;
            states[(int)PlayerStates.NoShoot] = noShoot;
            playerState = ready;
        }

        public void request()
        {
            playerState.handle(this);
        }

        public void changeState(PlayerStates state)
        {
            playerState = states[(int)state];
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitPlayer(this, pair);
        }

        public override void visitWallNode(WallNode wn, CollisionPair p)
        {
            p.collision(this, (GameObject)wn.Child);
        }

        public override void visitLeftWall(LeftWall lw, CollisionPair p)
        {
            p.notify(this, lw);
        }

        public override void visitRightWall(RightWall rw, CollisionPair p)
        {
            p.notify(this, rw);
        }

        public override void visitBomb(Bomb b, CollisionPair p)
        {
            p.notify(this, b);
        }


        public void moveLeft()
        {
            this.x -= playerState.moveLeft();
        }

        public void moveRight()
        {
            this.x += playerState.moveRight();
        }

        public void shoot()
        {
            playerState.shootMissile(this, this.x, this.y);
        }

        public override void update()
        {
            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_RIGHT) && canMoveRight)
            {
                moveRight();
                canMoveLeft = true;
            }
            else if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_LEFT) && canMoveLeft)
            {
                moveLeft();
                canMoveRight = true;
            }

            

            // Fires Missile
            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_SPACE) && !spacePressed)
            {
                shoot();
            }

            sprite.setPos(this.x, this.y);
            sprite.Color = this.goColor;
            colObj.setRectPos(this.x, this.y);
        }

        public override void draw()
        {
            this.sprite.draw();
        }

        public override Index getIndex()
        {
            return Index.Index_0;
        }

        public bool MoveLeft
        {
            get
            {
                return canMoveLeft;
            }
            set
            {
                canMoveLeft = value;
            }
        }
        public bool MoveRight
        {
            get
            {
                return canMoveRight;
            }
            set
            {
                canMoveRight = value;
            }
        }

    }
}
