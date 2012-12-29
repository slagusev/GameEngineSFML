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

      Game.EventMgr.Register(Event.KeyClick, c.KeyClick);
      Game.EventMgr.Register(Event.NextWorld, c.NextWorld);
    }

    public override void DeregisterEvents()
    {
      base.DeregisterEvents();
      Controller c = (Controller)Controller;

      Game.EventMgr.Deregister(Event.KeyClick, c.KeyClick);
      Game.EventMgr.Deregister(Event.NextWorld, c.NextWorld);
    }
  }
}
