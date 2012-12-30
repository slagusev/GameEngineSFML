using System;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Splash
{
  class Input : AInput
  {
    public override void Update()
    {
    }

    public void KeyDown(object keyEventArgs)
    {
      KeyEventArgs keyboard = (KeyEventArgs)keyEventArgs;

      if (keyboard.Code == Keyboard.Key.Left)
        Game.EventMgr.Notify(Event.Left, null);

      if (keyboard.Code == Keyboard.Key.Right)
        Game.EventMgr.Notify(Event.Right, null);

      if (keyboard.Code == Keyboard.Key.Up)
        Game.EventMgr.Notify(Event.Up, null);

      if (keyboard.Code == Keyboard.Key.Down)
        Game.EventMgr.Notify(Event.Down, null);
    }
  }
}
