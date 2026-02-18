using EmberKit.Geom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmberKit.Graphics
{
    public class SpriteText
    {
        public SpriteText(SpriteFont font)
        {
            Font = font;
            Visible = true;
            Scale = Vector2.One;
            Color = Color.White;
            Alpha = 1;
        }

        public SpriteText(SpriteFont font, string text) : this(font)
        {
            Text = text;
        }

        public SpriteText(SpriteFont font, int layer) : this(font)
        {
            Layer = layer;
        }

        public SpriteText(SpriteFont font, string text, int layer) : this(font, layer)
        {
            Text = text;
        }

        public Texture2D Tex => Font.Texture;
        public SpriteFont Font { get; }
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public Dimension Dimension
        {
            get
            {
                var (x, y) = Font.MeasureString(Text);
                return new Dimension(x, y);
            }
        }
        public Vector2 Anchor { get; set; }
        public bool Visible { get; set; }
        public Color Color { get; set; }
        public float Alpha { get; set; }
        public float Rotation { get; set; }
        public Vector2 Scale { get; set; }
        public int Layer { get; }
        
        public static void DrawTexts(SpriteText[] texts, SpriteBatch spriteBatch)
        {
            for (var i = 0; i < texts.Length; i++)
            {
                var text = texts[i];
                if (text == null || !text.Visible) continue;

                spriteBatch.DrawString(
                    text.Font,
                    text.Text,
                    text.Position - text.Anchor,
                    text.Color * text.Alpha, 
                    text.Rotation,
                    text.Anchor,
                    text.Scale,
                    SpriteEffects.None, 
                    0);
            }
        }
    }
}