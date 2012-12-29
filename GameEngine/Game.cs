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
    static GameWorld World;
    public static RenderWindow Context;
    public static EventManager EventMgr;
    public static Random Rand;

    const string WindowTitle = "Game Engine";
    const int FPS = 60;
    public const int Width = 1024;
    public const int Height = 640;
    static DateTime LastTime = DateTime.Now;
    public static long GameTime;
    public static float Delta = 0f;

    public static void Init()
    {
      Context = new RenderWindow(new VideoMode(Width, Height), WindowTitle);
      Context.Closed += OnClose;
      Context.KeyPressed += KeyPressed;
      Context.KeyReleased += KeyReleased;
      Context.MouseMoved += MouseMoved;
      Context.MouseButtonPressed += MouseButtonPressed;
      Context.MouseButtonReleased += MouseButtonReleased;
      Context.MouseWheelMoved += MouseWheelMoved;
      Context.JoystickButtonPressed += JoystickButtonPressed;
      Context.JoystickButtonReleased += JoystickButtonReleased;
      Context.JoystickConnected += JoystickConnected;
      Context.JoystickDisconnected += JoystickDisconnected;
      Context.JoystickMoved += JoystickMoved;

      Rand = new Random();
      EventMgr = new EventManager();
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
        Delta = (float)timeDiff.TotalSeconds;

        // Update
        Context.DispatchEvents();
        Update();

        // Draw
        Context.Clear();
        Draw();
        Context.Display();
      }
    }

    #region Input Events

    static void KeyPressed(object sender, KeyEventArgs e)
    {
      EventMgr.Notify(Event.KeyPressed, e);
    }

    static void KeyReleased(object sender, KeyEventArgs e)
    {
      EventMgr.Notify(Event.KeyReleased, e);
    }

    static void MouseMoved(object sender, MouseMoveEventArgs e)
    {
      EventMgr.Notify(Event.MouseMoved, e);
    }

    static void MouseButtonPressed(object sender, MouseButtonEventArgs e)
    {
      EventMgr.Notify(Event.MouseButtonPressed, e);
    }

    static void MouseButtonReleased(object sender, MouseButtonEventArgs e)
    {
      EventMgr.Notify(Event.MouseButtonReleased, e);
    }

    static void MouseWheelMoved(object sender, MouseWheelEventArgs e)
    {
      EventMgr.Notify(Event.MouseWheelMoved, e);
    }

    static void JoystickButtonPressed(object sender, JoystickButtonEventArgs e)
    {
      EventMgr.Notify(Event.JoystickButtonPressed, e);
    }

    static void JoystickButtonReleased(object sender, JoystickButtonEventArgs e)
    {
      EventMgr.Notify(Event.JoystickButtonReleased, e);
    }

    static void JoystickConnected(object sender, JoystickConnectEventArgs e)
    {
      EventMgr.Notify(Event.JoystickConnected, e);
    }

    static void JoystickDisconnected(object sender, JoystickConnectEventArgs e)
    {
      EventMgr.Notify(Event.JoystickDisconnected, e);
    }

    static void JoystickMoved(object sender, JoystickMoveEventArgs e)
    {
      EventMgr.Notify(Event.JoystickMoved, e);
    }

    #endregion

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
