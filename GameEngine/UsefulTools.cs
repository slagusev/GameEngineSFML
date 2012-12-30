using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine
{
  class UsefulTools
  {
    public static float TAU = (float)(Math.PI * 2);

    public static int Mod(int a, int n)
    {
      return ((a % n) + n) % n;
    }

    public static Image GenerateTexture2D(int size, Color color)
    {
      Color[,] colourData = new Color[size, size];

      for (int x = 0; x < size; x++)
        for (int y = 0; y < size; y++)
          colourData[x, y] = color;

      Image blank = new Image(colourData);

      return blank;
    }

    public static Image CreateCircle(int radius, int innerRadius)
    {
      int a = radius; // x center is radius
      int b = radius; // y center is radius
      uint diameter = (uint)radius * 2;

      Color[,] data = new Color[diameter, diameter];

      for (int x = 0; x < diameter; x++)
      {
        for (int y = 0; y < diameter; y++)
        {
          // Make Transparent
          data[x, y * radius * 2] = Color.Black;

          // Draw Outer Circle
          if ((x - a) * (x - a) + (y - b) * (y - b) <= radius * radius)
            data[x, y * radius * 2] = Color.White;

          // Remove Inner Circle
          if ((x - a) * (x - a) + (y - b) * (y - b) <= innerRadius * innerRadius)
            data[x, y * radius * 2] = Color.Black;
        }
      }

      Image texture = new Image(data);

      return texture;
    }

    /// <summary>
    /// Linearally interpolate between 2 values
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static float Lerp(float value1, float value2, float amount)
    {
      return (value1 + ((value2 - value1) * amount));
    }

    /// <summary>
    /// Linearally interpolate between 2 values
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static byte Lerp(byte value1, byte value2, float amount)
    {
      float v1 = value1;
      float v2 = value2;

      float res = v1 + ((v2 - v1) * amount);

      byte result = (byte)(v1 + ((v2 - v1) * amount));

      return result;
    }
  }
}
