using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EmberFramework.EngineSystems.Input;

public class InputManager
{
    private KeyboardState prevKeyboardState;
    private MouseState prevMouseState;

    public List<MouseMoveEvent> _mouseMoveEvents { get; } = new List<MouseMoveEvent>();
    public List<KeyboardInputEvent> KeyboardInputEvents { get; } = new List<KeyboardInputEvent>();
    public List<MouseInputEvent> MouseEvents { get; } = new List<MouseInputEvent>();

    public void Update()
    {
        var currKeyboardState = Keyboard.GetState();
        var currMouseState = Mouse.GetState();

        KeyboardInputEvents.Clear();
        MouseEvents.Clear();
        _mouseMoveEvents.Clear();

        foreach (var key in currKeyboardState.GetPressedKeys())
        {
            if (!prevKeyboardState.GetPressedKeys().Contains(key))
            {
                KeyboardInputEvents.Add(new KeyboardInputEvent(key, InputEventType.KeyPressed));
            }
        }

        foreach (var key in prevKeyboardState.GetPressedKeys())
        {
            if (!currKeyboardState.GetPressedKeys().Contains(key))
            {
                KeyboardInputEvents.Add(new KeyboardInputEvent(key, InputEventType.KeyReleased));
            }
        }

        if (currMouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
        {
            MouseEvents.Add(new MouseInputEvent(MouseButton.Left, InputEventType.ButtonPressed));
        }

        if (currMouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released)
        {
            MouseEvents.Add(new MouseInputEvent(MouseButton.Right, InputEventType.ButtonPressed));
        }

        if (currMouseState.MiddleButton == ButtonState.Pressed && prevMouseState.MiddleButton == ButtonState.Released)
        {
            MouseEvents.Add(new MouseInputEvent(MouseButton.Middle, InputEventType.ButtonPressed));
        }

        if (currMouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
        {
            MouseEvents.Add(new MouseInputEvent(MouseButton.Left, InputEventType.ButtonReleased));
        }

        if (currMouseState.RightButton == ButtonState.Released && prevMouseState.RightButton == ButtonState.Pressed)
        {
            MouseEvents.Add(new MouseInputEvent(MouseButton.Right, InputEventType.ButtonReleased));
        }

        if (currMouseState.MiddleButton == ButtonState.Released && prevMouseState.MiddleButton == ButtonState.Pressed)
        {
            MouseEvents.Add(new MouseInputEvent(MouseButton.Middle, InputEventType.ButtonReleased));
        }

        if (currMouseState.X != prevMouseState.X || currMouseState.Y != prevMouseState.Y)
        {
            _mouseMoveEvents.Add(new MouseMoveEvent(
                new Point(currMouseState.X - prevMouseState.X, currMouseState.Y - prevMouseState.Y),
                InputEventType.MouseMove));
            if (prevMouseState.LeftButton == ButtonState.Pressed &&
                currMouseState.LeftButton == ButtonState.Pressed)
            {
                _mouseMoveEvents.Add(new MouseMoveEvent(
                    new Point(currMouseState.X - prevMouseState.X, currMouseState.Y - prevMouseState.Y),
                    InputEventType.MouseDrag));
            }
        }


        prevKeyboardState = currKeyboardState;
        prevMouseState = currMouseState;
    }
}