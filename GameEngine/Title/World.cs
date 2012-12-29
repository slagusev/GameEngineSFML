using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Title
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
    }

    public override void DeregisterEvents()
    {
      base.DeregisterEvents();
      Controller c = (Controller)Controller;
    }
  }
}
