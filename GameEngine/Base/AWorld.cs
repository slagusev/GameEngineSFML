using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace GameEngine
{
  abstract class AWorld : IWorld
  {
    public AController Controller;
    public AInput Input;
    public AView View;

    public virtual void Update()
    {
      if (Input != null)
        Input.Update();

      if (Controller != null)
        Controller.Update();
    }

    public virtual void Draw(RenderWindow context)
    {
      if (View != null)
        View.Draw(context, Controller);
    }

    public virtual void RegisterEvents()
    {
      Game.EventMgr.Register(Event.MouseMoved, Input.MouseMoved);
      Game.EventMgr.Register(Event.MouseButtonPressed, Input.MouseButtonPressed);
      Game.EventMgr.Register(Event.MouseButtonReleased, Input.MouseButtonReleased);
      Game.EventMgr.Register(Event.MouseWheelMoved, Input.MouseWheelMoved);
      Game.EventMgr.Register(Event.KeyPressed, Input.KeyPressed);
      Game.EventMgr.Register(Event.KeyReleased, Input.KeyReleased);
    }

    public virtual void DeregisterEvents()
    {
      Game.EventMgr.Deregister(Event.MouseMoved, Input.MouseMoved);
      Game.EventMgr.Deregister(Event.MouseButtonPressed, Input.MouseButtonPressed);
      Game.EventMgr.Deregister(Event.MouseButtonReleased, Input.MouseButtonReleased);
      Game.EventMgr.Deregister(Event.MouseWheelMoved, Input.MouseWheelMoved);
      Game.EventMgr.Deregister(Event.KeyPressed, Input.KeyPressed);
      Game.EventMgr.Deregister(Event.KeyReleased, Input.KeyReleased);
    }
  }
}
