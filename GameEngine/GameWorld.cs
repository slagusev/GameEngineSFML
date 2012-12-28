using System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace GameEngine
{
  class GameWorld
  {
    public void Update(DateTime now, double delta)
    {
      Game.Context.SetTitle(delta.ToString());
    }

    public void Draw(RenderWindow context, DateTime now, double delta)
    {
      CircleShape ball = new CircleShape();
      ball.Radius = 50;
      ball.FillColor = new Color(Color.Magenta);
      ball.Position = new Vector2f(100, 150);
      context.Draw(ball);

      // Create a graphical string to display
      Text text = new Text("Hello World!");
      context.Draw(text);
    }

    public class Ball
    {
      int X;
      int Y;

      public Ball(int x, int y)
      {
      }

      public void Update() { }
      public void Draw() { }
    }
  }
}
