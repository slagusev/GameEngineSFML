using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace GameEngine
{
  abstract class AView : IView
  {
    public abstract void Draw(RenderWindow context, AController controller);
  }
}
