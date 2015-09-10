using System;

namespace SpaceInvaders
{
    // Texture Enums
    enum TexEnum
    {
        AlienTex,
        ShieldTex,
        MissileExplode,
        // Texture with most on it, that isn't AlienTex
        SpaceTex,
        BombTex,
        MissileTex,
        SplashTex
    }

    // Image Enums
    enum ImageEnum
    {
        Squid_1, Squid_2,
        Octo_1, Octo_2,
        Crab_1, Crab_2,
        
        // Middile Blocks
        ShieldBlock,
        // Top Left
        LeftTop_1, LeftTop_2, LeftTop_3, LeftTop_4,
        // Top Right
        RightTop_1, RightTop_2, RightTop_3, RightTop_4,
        // Bottom left
        LeftBottom_1, LeftBottom_2, LeftBottom_3, LeftBottom_4,
        // Bottom right
        RightBottom_1, RightBottom_2, RightBottom_3, RightBottom_4,

        Player, PlayerExplosion_1, PlayerExplosion_2,
        Missile,
        Splat,
        Explosion,
        Line, Cross, ZigZag, UFOBomb,
        UFO,
        Splash,
        NullObj,
        Not_Initialized
    }

    // Sprite Enums
    enum SpriteEnum
    {
        Collision,
        Squid,
        Octo,
        Crab,
        UFO,
        Shields,
        Player,
        PlayerExplosion,
        Missile,
        Splat,
        Explosion,
        Line, Cross, ZigZag,
         // Middile Blocks
        ShieldBlock,
        // Top Left
        LeftTop_0, LeftTop_1, LeftTop_2, LeftTop_3,
        // Top Right
        RightTop_0, RightTop_1, RightTop_2, RightTop_3,
        // Bottom left
        LeftBottom_0, LeftBottom_1, LeftBottom_2, LeftBottom_3,
        // Bottom right
        RightBottom_0, RightBottom_1, RightBottom_2, RightBottom_3,

        Splash,
        Null,
        Not_Initialized
    }

    enum Index
    {
        Index_Null,
        Index_0,
        Index_1,
        Index_2,
        Index_3,
        Index_4,
        Index_5,
        Index_6,
        Index_7,
        Index_8,
        Index_9,
        Index_10,
        Index_11,
        Index_12,
        Index_13,
        Index_14,
        Index_15,
        Index_16,
        Index_17,
        Index_18,
        Index_19,
        Index_20,
        Index_21,
        Index_22,
    }
}
