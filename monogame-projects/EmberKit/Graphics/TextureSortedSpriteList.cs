using System;
using Microsoft.Xna.Framework.Graphics;

namespace EmberKit.Graphics
{
    public class TextureSortedSpriteList : ISpriteList
    {
        private readonly Texture2D[] _textures;
        private readonly int[] _textureAdresses;
        private readonly SparseArraySpriteList[] _lists;
        private readonly Sprite[] _sortedSprites;

        public TextureSortedSpriteList(Texture2D[] textures, int[] capacities)
        {
            _textures = textures;
            _textureAdresses = new int[textures.Length];
            _lists = new SparseArraySpriteList[textures.Length];
            var total = 0;
            for (var i = 0; i < textures.Length; i++)
            {
                _textureAdresses[i] = total;
                total += capacities[i];
                _lists[i] = new SparseArraySpriteList(capacities[i]);
            }
            _sortedSprites = new Sprite[total];
        }

        public Sprite[] Sprites => _sortedSprites;
        public int Capacity => _sortedSprites.Length;

        public void Clear()
        {
            for (var i = 0; i < _lists.Length; i++)
            {
                _lists[i].Clear();
            }
            Array.Clear(_sortedSprites, 0, _sortedSprites.Length);
        }

        public int AddSprite(Sprite sprite)
        {
            var textureIndex = Array.IndexOf(_textures, sprite.Texture);
            var spriteIndex = _lists[textureIndex].AddSprite(sprite);
            var sortedSpriteIndex = _textureAdresses[textureIndex] + spriteIndex;
            _sortedSprites[sortedSpriteIndex] = sprite;
            return sortedSpriteIndex;
        }

        public int RemoveSprite(Sprite sprite)
        {
            var textureIndex = Array.IndexOf(_textures, sprite.Texture);
            var spriteIndex = _lists[textureIndex].RemoveSprite(sprite);
            var sortedSpriteIndex = _textureAdresses[textureIndex] + spriteIndex;
            _sortedSprites[sortedSpriteIndex] = null;
            return sortedSpriteIndex;
        }
    }
}