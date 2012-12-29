using System;
using System.Timers;
using System.Threading;
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
    public static long GameTime;
    public static double Delta = 0.0d;

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
        GameTime++;

        LastTime = DateTime.UtcNow;

        Thread.Sleep(1000 / FPS);

        TimeSpan timeDiff = DateTime.UtcNow - LastTime;
        Delta = timeDiff.TotalSeconds;

        // Update
        Context.DispatchEvents();
        Update();

        // Draw
        Context.Clear();
        Draw();
        Context.Display();
      }
    }

    static void OnClose(object sender, EventArgs e)
    {
      RenderWindow window = (RenderWindow)sender;
      window.Close();
    }

    public static void Update()
    {
      if (World != null)
        World.Update();
    }

    public static void Draw()
    {
      if (World != null)
        World.Draw(Context);
    }
  }
}
