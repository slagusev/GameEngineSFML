using System;
using System.IO;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Splash
{
  class View : AView
  {
    Sprite Domey;

    public View() 
    {
      Sprite domey = DAO.GetSprite(Element.Domey);
      Domey = new Sprite(domey);
      Domey.Position = new Vector2f(200, 300);
    }

    public override void Draw(RenderWindow context, AController controller)
    {
      Controller c = (Controller)controller;

      foreach (Ball ball in c.Balls)
        ball.Draw(context);

      Text text = new Text("Splash Screen");
      context.Draw(text);

      context.Draw(Domey);
    }
  }
}
