using System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace GameEngine
{
  class Ball
  {
    Vector2f Position;
    Vector2f Velocity;
    int Radius;
    Color Colour;
    CircleShape Circle;
    float Speed;

    public Ball(int x, int y, int radius, Color colour)
    {
      Position = new Vector2f(x, y);
      Velocity = new Vector2f(
        (float)Game.Rand.NextDouble(),
        (float)Game.Rand.NextDouble());
      Radius = radius;
      Colour = colour;
      Speed = 600;

      Circle = new CircleShape();
      Circle.Radius = Radius;
    }

    public void Update()
    {
      Position.X += Velocity.X * Game.Delta * Speed;
      Position.Y += Velocity.Y * Game.Delta * Speed;

      if (Position.X <= 0 || Position.X + Radius * 2 >= Game.Width)
        Velocity.X *= -1;

      if (Position.Y <= 0 || Position.Y + Radius * 2 >= Game.Height)
        Velocity.Y *= -1;
    }

    public void Draw(RenderWindow context)
    {
      Circle.FillColor = Colour;
      Circle.Position = Position;

      context.Draw(Circle);
    }
  }
}
