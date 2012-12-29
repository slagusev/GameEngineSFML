using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace GameEngine
{
  interface IView
  {
    void Draw(RenderWindow context, AController controller);
  }
}
