using System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace GameEngine
{
  public class Game
  {
    public static RenderWindow Context;
    static GameWorld World;

    const string WindowTitle = "Game Engine";
    const int FPS = 60;
    const int Width = 1024;
    const int Height = 640;
    static DateTime LastTime = DateTime.Now;

    public static void Init()
    {
      Context = new RenderWindow(new VideoMode(Width, Height), WindowTitle);
      Context.Closed += OnClose;

      World = new GameWorld();
    }

    public static void Run()
    {
      Init();

      while (Context.IsOpen())
      {
        LastTime = DateTime.UtcNow;

        // Pause
        DateTime timeTo = DateTime.UtcNow.AddSeconds(1.0f / FPS);
        while (DateTime.UtcNow < timeTo) { }

        // GameTime and Time Delta
        TimeSpan timeDiff = DateTime.UtcNow - LastTime;
        double delta = timeDiff.TotalSeconds;

        // Update
        Context.DispatchEvents();
        Update(delta);

        // Draw
        Context.Clear();
        Draw(delta);
        Context.Display();
      }
    }

    static void OnClose(object sender, EventArgs e)
    {
      RenderWindow window = (RenderWindow)sender;
      window.Close();
    }

    public static void Update(double delta)
    {
      if (World != null)
        World.Update(DateTime.UtcNow, delta);
    }

    public static void Draw(double delta)
    {
      if (World != null)
        World.Draw(Context, DateTime.UtcNow, delta);
    }
  }
}
