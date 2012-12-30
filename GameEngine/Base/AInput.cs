using System;
using System.Collections.Generic;
using SFML.Window;

namespace GameEngine
{
  abstract class AInput : IInput
  {
    Dictionary<Keyboard.Key, bool> LastKeyboard = new Dictionary<Keyboard.Key, bool>();
    bool LastLeftState = false;
    bool LastRightState = false;
    bool LastMiddleState = false;
    bool[] LastJoystickButtons = new bool[12];

    public abstract void Update();

    public void MouseMoved(object mouseMoveEventArgs)
    {
      MouseMoveEventArgs mouse = (MouseMoveEventArgs)mouseMoveEventArgs;
      int x = mouse.X;
      int y = mouse.Y;
    }

    public void MouseButtonPressed(object mouseButtonEventArgs)
    {
      MouseButtonEventArgs mouse = (MouseButtonEventArgs)mouseButtonEventArgs;

      int x = mouse.X;
      int y = mouse.Y;

      bool left = mouse.Button.Equals(Mouse.Button.Left);
      bool right = mouse.Button.Equals(Mouse.Button.Right);
      bool middle = mouse.Button.Equals(Mouse.Button.Middle);

      if (LastLeftState)
        Game.EventMgr.Notify(Event.LeftMouseDown, mouseButtonEventArgs);

      if (LastRightState)
        Game.EventMgr.Notify(Event.RightMouseDown, mouseButtonEventArgs);

      if (LastMiddleState)
        Game.EventMgr.Notify(Event.MiddleMouseDown, mouseButtonEventArgs);

      LastLeftState = left;
      LastMiddleState = middle;
      LastRightState = right;
    }

    public void MouseButtonReleased(object mouseButtonEventArgs)
    {
      MouseButtonEventArgs mouse = (MouseButtonEventArgs)mouseButtonEventArgs;

      int x = mouse.X;
      int y = mouse.Y;

      bool left = mouse.Button.Equals(Mouse.Button.Left);
      bool right = mouse.Button.Equals(Mouse.Button.Right);
      bool middle = mouse.Button.Equals(Mouse.Button.Middle);

      if (LastLeftState && !left)
        Game.EventMgr.Notify(Event.LeftMouseClick, mouseButtonEventArgs);

      if (LastRightState && !right)
        Game.EventMgr.Notify(Event.RightMouseClick, mouseButtonEventArgs);

      if (LastMiddleState && !middle)
        Game.EventMgr.Notify(Event.MiddleMouseClick, mouseButtonEventArgs);

      LastLeftState = left;
      LastRightState = right;
      LastMiddleState = middle;
    }

    public void MouseWheelMoved(object mouseWheelEventArgs)
    {
      MouseWheelEventArgs mouse = (MouseWheelEventArgs)mouseWheelEventArgs;

      if (mouse.Delta > 0)
        Game.EventMgr.Notify(Event.ScrollDown, mouse);
      else if (mouse.Delta < 0)
        Game.EventMgr.Notify(Event.ScrollUp, mouse);
    }

    public void KeyPressed(object keyEventArgs)
    {
      KeyEventArgs keys = (KeyEventArgs)keyEventArgs;

      if (!LastKeyboard.ContainsKey(keys.Code))
        LastKeyboard.Add(keys.Code, true);

      Game.EventMgr.Notify(Event.KeyDown, keys);
    }

    public void KeyReleased(object keyEventArgs)
    {
      KeyEventArgs keys = (KeyEventArgs)keyEventArgs;

      if (LastKeyboard.ContainsKey(keys.Code) && LastKeyboard[keys.Code])
      {
        Game.EventMgr.Notify(Event.KeyClick, keys);
      }

      Game.EventMgr.Notify(Event.KeyUp, keys);
    }

    public void JoystickButtonPressed(object joystickButtonEventArgs)
    {
      JoystickButtonEventArgs joystick = (JoystickButtonEventArgs)joystickButtonEventArgs;

      for (int i = 0; i < LastJoystickButtons.Length; i++)
        if (joystick.Button == i)
          LastJoystickButtons[i] = true;

      Game.EventMgr.Notify(Event.JoystickBtnDown, joystickButtonEventArgs);
    }

    public void JoystickButtonReleased(object joystickButtonEventArgs)
    {
      JoystickButtonEventArgs joystick = (JoystickButtonEventArgs)joystickButtonEventArgs;

      for (int i = 0; i < LastJoystickButtons.Length; i++)
      {
        if (joystick.Button == i)
        {
          if (LastJoystickButtons[i])
            Game.EventMgr.Notify(Event.JoystickBtnClick, joystickButtonEventArgs);

          LastJoystickButtons[i] = false;
        }
      }

      Game.EventMgr.Notify(Event.JoystickBtnUp, joystickButtonEventArgs);
    }

    public void JoystickConnected(object joystickConnectEventArgs)
    {
      JoystickConnectEventArgs joystick = (JoystickConnectEventArgs)joystickConnectEventArgs;
    }

    public void JoystickDisconnected(object joystickConnectEventArgs)
    {
      JoystickConnectEventArgs joystick = (JoystickConnectEventArgs)joystickConnectEventArgs;
    }

    public void JoystickMoved(object joystickMoveEventArgs)
    {
      JoystickMoveEventArgs joystick = (JoystickMoveEventArgs)joystickMoveEventArgs;
      bool xAxis = joystick.Axis == Joystick.Axis.X;
      bool yAxis = joystick.Axis == Joystick.Axis.Y;

      float direction = joystick.Position;

      if (xAxis && direction < 0)
        Game.EventMgr.Notify(Event.JoystickMoveLeft, joystick);
      else if (xAxis && direction > 0)
        Game.EventMgr.Notify(Event.JoystickMoveRight, joystick);
      else if (yAxis && direction < 0)
        Game.EventMgr.Notify(Event.JoystickMoveUp, joystick);
      else if (yAxis && direction > 0)
        Game.EventMgr.Notify(Event.JoystickMoveDown, joystick);
    }
  }
}
