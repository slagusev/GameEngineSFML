﻿using System;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Title
{
  class View : AView
  {
    public override void Draw(RenderWindow context, AController controller)
    {
      Controller c = (Controller)controller;

      foreach (Ball ball in c.Balls)
        ball.Draw(context);

      Text text = new Text("Title Screen");
      context.Draw(text);
    }
  }
}
