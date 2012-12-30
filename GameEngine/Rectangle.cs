using System;

namespace GameEngine
{
  struct Rectangle
  {
    public int X;
    public int Y;
    public int Width;
    public int Height;

    public int Left { get { return X; } }
    public int Right { get { return X + Width; } }
    public int Top { get { return Y; } }
    public int Bottom { get { return Y + Height; } }

    public Rectangle(int x, int y, int width, int height)
    {
      X = x;
      Y = y;
      Width = width;
      Height = height;
    }

    public bool Intersects(Rectangle b)
    {
      if (Left <= b.Right
        && b.Left <= Right
        && Top <= b.Bottom
        && b.Top <= Bottom)
        return true;

      return false;
    }
  }
}
