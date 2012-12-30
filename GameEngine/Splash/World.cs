using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Splash
{
  class World : AWorld
  {
    public World()
    {
      Controller = new Controller();
      Input = new Input();
      View = new View();

      RegisterEvents();
    }

    public override void RegisterEvents()
    {
      base.RegisterEvents();
      Controller c = (Controller)Controller;
      Input i = (Input)Input;

      Game.EventMgr.Register(Event.KeyClick, c.KeyClick);
      Game.EventMgr.Register(Event.NextWorld, c.NextWorld);
      Game.EventMgr.Register(Event.KeyDown, i.KeyDown);
      Game.EventMgr.Register(Event.Left, c.Left);
      Game.EventMgr.Register(Event.Right, c.Right);
      Game.EventMgr.Register(Event.Up, c.Up);
      Game.EventMgr.Register(Event.Down, c.Down);
      Game.EventMgr.Register(Event.KeyReleased, c.KeyReleased);
    }

    public override void DeregisterEvents()
    {
      base.DeregisterEvents();
      Controller c = (Controller)Controller;
      Input i = (Input)Input;

      Game.EventMgr.Deregister(Event.KeyClick, c.KeyClick);
      Game.EventMgr.Deregister(Event.NextWorld, c.NextWorld);
      Game.EventMgr.Deregister(Event.KeyDown, i.KeyDown);
      Game.EventMgr.Deregister(Event.Left, c.Left);
      Game.EventMgr.Deregister(Event.Right, c.Right);
      Game.EventMgr.Deregister(Event.Up, c.Up);
      Game.EventMgr.Deregister(Event.Down, c.Down);
      Game.EventMgr.Deregister(Event.KeyReleased, c.KeyReleased);
    }
  }
}
