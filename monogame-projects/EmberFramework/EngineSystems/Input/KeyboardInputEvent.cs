using Microsoft.Xna.Framework.Input;

namespace EmberFramework.EngineSystems.Input;


public class KeyboardInputEvent
{
    public KeyboardInputEvent(Keys key, InputEventType eventType)
    {
        Key = key;
        EventType = eventType;
    }

    public Keys Key { get; }
    public InputEventType EventType { get; }
}

