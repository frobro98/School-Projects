using System;

namespace SpaceInvaders
{
    class AssetManager
    {
        private static AssetManager amInstance = null;

        private AssetManager()
        {

        }

        public static void initialize()
        {
            TextureManager.initialize(5, 1);
            ImageManager.initialize(29, 1);
            GameSpriteManager.initialize(25, 1);
            CollisionSpriteManager.initialize(1, 1);
            CommandContainer.initialize(6, 1);
            DestroyManager.initialize();
        }

        public static void loadContent()
        {
            TextureManager.add(TexEnum.AlienTex, "invader-texture.tga");
            TextureManager.add(TexEnum.ShieldTex, "shield.tga");
            TextureManager.add(TexEnum.SpaceTex, "ArcadeQuality.tga");
            TextureManager.add(TexEnum.BombTex, "ammo.tga");
            TextureManager.add(TexEnum.MissileExplode, "explosions.tga");
            TextureManager.add(TexEnum.SplashTex, "splash screen.tga");
            ImageManager.add(ImageEnum.Squid_1, TexEnum.AlienTex, 370, 65, 62, 62);
            ImageManager.add(ImageEnum.Squid_2, TexEnum.AlienTex, 465, 65, 62, 62);
            ImageManager.add(ImageEnum.Octo_1, TexEnum.AlienTex, 559, 65, 93, 62);
            ImageManager.add(ImageEnum.Octo_2, TexEnum.AlienTex, 27, 202, 93, 62);
            ImageManager.add(ImageEnum.Crab_1, TexEnum.AlienTex, 136, 65, 85, 62);
            ImageManager.add(ImageEnum.Crab_2, TexEnum.AlienTex, 253, 65, 85, 62);
            ImageManager.add(ImageEnum.UFO, TexEnum.AlienTex, 122, 491, 95, 44);
            ImageManager.add(ImageEnum.Splash, TexEnum.SplashTex, 31f, 63f, 169f, 131f);
            ImageManager.add(ImageEnum.Player, TexEnum.AlienTex, 243, 494, 57, 40);
            ImageManager.add(ImageEnum.PlayerExplosion_1, TexEnum.SpaceTex, 204, 60, 60, 32);
            ImageManager.add(ImageEnum.PlayerExplosion_2, TexEnum.SpaceTex, 268, 60, 64, 32);
            ImageManager.add(ImageEnum.Explosion, TexEnum.MissileExplode, 0f, 0f, 37, 33);
            ImageManager.add(ImageEnum.Missile, TexEnum.SpaceTex, 116, 72, 4, 16);
            ImageManager.add(ImageEnum.Splat, TexEnum.AlienTex, 490, 489, 73, 44);
            ImageManager.add(ImageEnum.Line, TexEnum.SpaceTex, 444, 64, 4, 28);
            ImageManager.add(ImageEnum.Cross, TexEnum.SpaceTex, 352, 68, 12, 24);
            ImageManager.add(ImageEnum.ZigZag, TexEnum.SpaceTex, 392, 64, 12, 28);
            // Top corners
            ImageManager.add(ImageEnum.LeftTop_1, TexEnum.SpaceTex, 16, 60, 10, 4);
            ImageManager.add(ImageEnum.LeftTop_2, TexEnum.SpaceTex, 16, 56, 10, 4);
            ImageManager.add(ImageEnum.LeftTop_3, TexEnum.SpaceTex, 26, 52, 10, 4);
            ImageManager.add(ImageEnum.LeftTop_4, TexEnum.SpaceTex, 26, 48, 10, 4);
            ImageManager.add(ImageEnum.RightTop_1, TexEnum.SpaceTex, 84, 48, 10, 4);
            ImageManager.add(ImageEnum.RightTop_2, TexEnum.SpaceTex, 84, 52, 10, 4);
            ImageManager.add(ImageEnum.RightTop_3, TexEnum.SpaceTex, 93, 56, 10, 4);
            ImageManager.add(ImageEnum.RightTop_4, TexEnum.SpaceTex, 94, 60, 10, 4);
            // Bottom corners
            ImageManager.add(ImageEnum.LeftBottom_1, TexEnum.SpaceTex, 36, 100, 10, 4);
            ImageManager.add(ImageEnum.LeftBottom_2, TexEnum.SpaceTex, 36, 96, 10, 4);
            ImageManager.add(ImageEnum.RightBottom_1, TexEnum.SpaceTex, 70, 96, 10, 4);
            ImageManager.add(ImageEnum.RightBottom_2, TexEnum.SpaceTex, 70, 100, 10, 4);
            ImageManager.add(ImageEnum.ShieldBlock, TexEnum.SpaceTex, 16, 108, 10, 4);

            GameSpriteManager.add(SpriteEnum.Squid, Index.Index_Null, ImageEnum.Squid_1, 0, 0, 28.4f, 32.6f);
            GameSpriteManager.add(SpriteEnum.Crab, Index.Index_Null, ImageEnum.Crab_1, 0, 0, 38.0f, 38.4f);
            GameSpriteManager.add(SpriteEnum.Octo, Index.Index_Null, ImageEnum.Octo_1, 0, 0, 50.0f, 38.0f);
            GameSpriteManager.add(SpriteEnum.Player, Index.Index_Null, ImageEnum.Player, 0f, 0f, 47.0f, 34.0f);
            GameSpriteManager.add(SpriteEnum.PlayerExplosion, Index.Index_Null, ImageEnum.PlayerExplosion_1, 0f, 0f, 47f, 34f);
            GameSpriteManager.add(SpriteEnum.UFO, Index.Index_Null, ImageEnum.UFO, 0f, 0f, 90f, 40f);

            GameSpriteManager.add(SpriteEnum.Splash, Index.Index_Null, ImageEnum.Splash, 0f, 0f, 600f, 600f);
            GameSpriteManager.add(SpriteEnum.Splat, Index.Index_Null, ImageEnum.Splat, 0, 0, 45f, 30.4f);
            GameSpriteManager.add(SpriteEnum.Explosion, Index.Index_Null, ImageEnum.Explosion, 0f, 0f, 1f, 1f);
            GameSpriteManager.add(SpriteEnum.Missile, Index.Index_Null, ImageEnum.Missile, -50.0f, -50.0f, 4f, 15f);
            GameSpriteManager.add(SpriteEnum.Line, Index.Index_Null, ImageEnum.Line, 0f, 0f, 4f, 25f);
            GameSpriteManager.add(SpriteEnum.Cross, Index.Index_Null, ImageEnum.Cross, 0f, 0f, 10f, 25f);
            GameSpriteManager.add(SpriteEnum.ZigZag, Index.Index_Null, ImageEnum.ZigZag, 0f, 0f, 13f, 30f);
            GameSpriteManager.add(SpriteEnum.ShieldBlock, Index.Index_Null, ImageEnum.ShieldBlock, 0f, 0f, 15f, 10f);
            // Top Corners
            GameSpriteManager.add(SpriteEnum.LeftTop_0, Index.Index_Null, ImageEnum.LeftTop_1, 0f, 0f, 15f, 5f);
            GameSpriteManager.add(SpriteEnum.LeftTop_1, Index.Index_Null, ImageEnum.LeftTop_2, 0f, 0f, 15f, 5f);
            GameSpriteManager.add(SpriteEnum.LeftTop_2, Index.Index_Null, ImageEnum.LeftTop_3, 0f, 0f, 15f, 5f);
            GameSpriteManager.add(SpriteEnum.LeftTop_3, Index.Index_Null, ImageEnum.LeftTop_4, 0f, 0f, 15f, 5f);

            GameSpriteManager.add(SpriteEnum.RightTop_0, Index.Index_Null, ImageEnum.RightTop_1, 0f, 0f, 15f, 5f);
            GameSpriteManager.add(SpriteEnum.RightTop_1, Index.Index_Null, ImageEnum.RightTop_2, 0f, 0f, 15f, 5f);
            GameSpriteManager.add(SpriteEnum.RightTop_2, Index.Index_Null, ImageEnum.RightTop_3, 0f, 0f, 15f, 5f);
            GameSpriteManager.add(SpriteEnum.RightTop_3, Index.Index_Null, ImageEnum.RightTop_4, 0f, 0f, 15f, 5f);
            // Bottom Corners
            GameSpriteManager.add(SpriteEnum.LeftBottom_0, Index.Index_Null, ImageEnum.LeftBottom_1, 0f, 0f, 15f, 5f);
            GameSpriteManager.add(SpriteEnum.LeftBottom_1, Index.Index_Null, ImageEnum.LeftBottom_2, 0f, 0f, 15f, 5f);
            GameSpriteManager.add(SpriteEnum.RightBottom_0, Index.Index_Null, ImageEnum.RightBottom_1, 0f, 0f, 15f, 5f);
            GameSpriteManager.add(SpriteEnum.RightBottom_1, Index.Index_Null, ImageEnum.RightBottom_2, 0f, 0f, 15f, 5f);

            CollisionSpriteManager.add(SpriteEnum.Collision, Index.Index_Null, new Azul.Color(1.0f, 0, 0), 0.0f, 0.0f, 0.0f, 0.0f);
        }

        private static AssetManager Instance
        {
            get
            {
                if (amInstance == null)
                {
                    amInstance = new AssetManager();
                }

                return amInstance;
            }
        }
    }
}
