using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace GameEngine
{
  interface IWorld
  {
    void Update();
    void Draw(RenderWindow context);

    void RegisterEvents();
    void DeregisterEvents();
  }
}
