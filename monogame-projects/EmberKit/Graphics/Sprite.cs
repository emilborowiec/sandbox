using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmberKit.Graphics
{
    public class Sprite
    {
        public Sprite(Texture2D texture)
        {
            Texture = texture;
            Visible = true;
            Scale = Vector2.One;
            Tint = Color.White;
            Alpha = 1;
            Clip = new Rectangle(0, 0, texture.Width, texture.Height);
            Width = texture.Width;
            Height = texture.Height;
        }

        public Sprite(Texture2D texture, int layer) : this(texture)
        {
            Layer = layer;
        }

        public Sprite(Texture2D texture, int layer, Rectangle clippingRectangle) : this(texture, layer)
        {
            Clip = clippingRectangle;
            Width = clippingRectangle.Width;
            Height = clippingRectangle.Height;
        }

        public Texture2D Texture { get; }
        public Rectangle Clip { get; set; }
        public Vector2 Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool Visible { get; set; }
        public Vector2 Anchor { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }
        public int Layer { get; }
        public Color Tint { get; set; }
        public float Alpha { get; set; }

        public Rectangle GetRectangle()
        {
            var width = Width * Scale.X;
            var height = Height * Scale.Y;
            return new Rectangle((int) (Position.X - Anchor.X), (int) (Position.Y - Anchor.Y),
                (int) width, (int) height);
        }

        public void CenterAnchor()
        {
            Anchor = new Vector2(Width/2, Height/2);
        }
        
        public static void DrawSprites(Sprite[] sprites, SpriteBatch spriteBatch)
        {
            for (var i = 0; i < sprites.Length; i++)
            {
                var sprite = sprites[i];
                DrawSprite(sprite, spriteBatch);
            }
        }

        public static void DrawSprites(List<Sprite> sprites, SpriteBatch spriteBatch)
        {
            for (var i = 0; i < sprites.Count; i++)
            {
                var sprite = sprites[i];
                DrawSprite(sprite, spriteBatch);
            }
        }

        public static void DrawSprite(Sprite sprite, SpriteBatch spriteBatch)
        {
            if (sprite == null || !sprite.Visible) return;
            var rect = sprite.GetRectangle();

            spriteBatch.Draw(
                sprite.Texture,
                rect,
                sprite.Clip,
                sprite.Tint * sprite.Alpha,
                sprite.Rotation,
                sprite.Anchor,
                SpriteEffects.None,
                0);
        }
    }
}