namespace EmberKit.Graphics
{
    public interface ISpriteList
    {
        Sprite[] Sprites { get; }
        int Capacity { get; }
        int AddSprite(Sprite sprite);
        int RemoveSprite(Sprite sprite);
        void Clear();
    }
}