namespace EmberFramework.EngineSystems.Input;

public class MouseInputEvent
{
    public MouseInputEvent(MouseButton button, InputEventType eventType)
    {
        Button = button;
        EventType = eventType;
    }

    public MouseButton Button { get; }
    public InputEventType EventType { get; }
}