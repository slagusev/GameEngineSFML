using System;
using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace GameEngine
{
  enum Screen { Null, Splash, Title, Level0, EndCredits }

  class GameWorld
  {
    static AWorld World;
    private static Screen NewWorld;

    public GameWorld()
    {
      // Load Images
      DAO.LoadImages();
      DAO.LoadSound();
      DAO.LoadMusic();

      // Default World to load
      World = new Splash.World();

      DAO.GetSound(SoundElement.Tone1).Play();
    }

    public void Update()
    {
      LoadNewWorld();

      if (World != null)
        World.Update();
    }

    private static void LoadNewWorld()
    {
      if (NewWorld != Screen.Null)
      {
        if (World != null)
          World.DeregisterEvents();

        switch (NewWorld)
        {
          case Screen.Splash:
            World = new Splash.World();
            break;
          case Screen.Title:
            World = new Title.World();
            break;
          case Screen.Level0:
            // World = new Level0.World();
            break;
          case Screen.EndCredits:
            // World = new EndCredits.World();
            break;
        }

        NewWorld = Screen.Null;
      }
    }

    public void Draw(RenderWindow context)
    {
      if (World != null)
        World.Draw(context);
    }

    public static void LoadScreen(Screen screen)
    {
      NewWorld = screen;
    }
  }
}
