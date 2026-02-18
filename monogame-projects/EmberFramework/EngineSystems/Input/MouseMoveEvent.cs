using Microsoft.Xna.Framework;

namespace EmberFramework.EngineSystems.Input;

public class MouseMoveEvent
{
    public MouseMoveEvent(Point displacement, InputEventType eventType)
    {
        Displacement = displacement;
        EventType = eventType;
    }

    public Point Displacement { get; }
    public InputEventType EventType { get; }
}