using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollisionManager;
using Box2D.XNA;

namespace SpriteAnimation
{
    class TimeEvent
    {
        public TimeEvent(TimeSpan _time, callback _funcCallBack)
        {
            this.time = _time;
            this.funcCB = _funcCallBack;
            this.dataCB = null;
            this.next = null;
            this.prev = null;
        }

        public delegate void callback(object obj);

        // connectors
        public TimeEvent prev;
        public TimeEvent next;

        // data
        public object dataCB;
        public TimeSpan time;
        public callback funcCB;

    }

    class CallBackData
    {
        public CallBackData(int initialCountValue, TimeSpan _delta)
        {
            this.count = initialCountValue;
            this.targetTime = new TimeSpan();
            this.deltaTime = _delta;
        }
        // data store, holds my instance data for my callback
        public int count;
        public TimeSpan targetTime;
        public TimeSpan deltaTime;
        public Sprite_Proxy spriteRef;
        public PlayerID playerID;
    }
}
