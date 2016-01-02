using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using CollisionManager;

namespace OmegaRace
{

    enum InputType
    {
        Forward,
        RotateLeft,
        RotateRight,
        FireMissile,
        DropBomb,
        Collision,
        NotInitialied
    }

    // Input Header
    struct InputHdr
    {
        public InputType input;
        public PlayerID player;
        public object colInfo;
        public bool networked;
    }

    struct ColHdr
    {
        public int goID1;
        public int goID2;
        public Vector2 pos;
    }

    // Update header
    struct LocationHdr
    {
        public Vector2 position;
        public float rotation;
        public int goIndex;
        public bool networked;
    }
}
