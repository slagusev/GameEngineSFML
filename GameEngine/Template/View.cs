using System;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Template
{
  class View : AView
  {
    public override void Draw(RenderWindow context, AController controller)
    {
      Controller c = (Controller)controller;
    }
  }
}
