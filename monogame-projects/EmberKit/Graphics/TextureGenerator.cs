using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmberKit.Graphics
{
    public static class TextureGenerator
    {
        public static Texture2D CreatePixel(GraphicsDevice device, Color color)
        {
            return CreateTexture(device, 1, 1, index => color);
        }
        
        public static Texture2D CreateTexture(GraphicsDevice device, int width,int height, Func<int,Color> paint)
        {
            //initialize a texture
            Texture2D texture = new Texture2D(device, width, height);

            //the array holds the color for each pixel in the texture
            Color[] data = new Color[width * height];
            for(var pixelIndex=0; pixelIndex<data.Length; pixelIndex++)
            {
                data[pixelIndex] = paint(pixelIndex);
            }

            //set the color
            texture.SetData(data);

            return texture;
        }
    }
}