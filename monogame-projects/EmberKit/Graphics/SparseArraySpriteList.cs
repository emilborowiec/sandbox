using EmberKit.DataStructs;

namespace EmberKit.Graphics
{
    public class SparseArraySpriteList : ISpriteList
    {
        private SparseArray<Sprite> _sprites;
        
        public SparseArraySpriteList(int capacity)
        {
            _sprites = new SparseArray<Sprite>(capacity);
        }

        public Sprite[] Sprites => _sprites.Elements;
        public int Capacity => _sprites.Capacity;
        
        public int AddSprite(Sprite sprite)
        {
            return _sprites.AddElement(sprite);
        }

        public int RemoveSprite(Sprite sprite)
        {
            return _sprites.RemoveElement(sprite);
        }

        public void Clear()
        {
            _sprites.Clear();
        }
    }
}