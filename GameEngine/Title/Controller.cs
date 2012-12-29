using System;
using System.Collections.Generic;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Title
{
  class Controller : AController
  {
    public List<Ball> Balls;

    public Controller()
    {
      Balls = new List<Ball>();
      Balls.Add(new Ball(100, 100, 20, Color.Red));
    }

    public override void Update()
    {
      foreach (Ball ball in Balls)
        ball.Update();
    }

    #region Events

    public void NextWorld(object screen)
    {
      GameWorld.LoadScreen((Screen)screen);
    }

    public void KeyClick(object keyEventArgs)
    {
      KeyEventArgs keyboard = (KeyEventArgs)keyEventArgs;

      if (keyboard.Code == Keyboard.Key.N)
        Game.EventMgr.Notify(Event.NextWorld, Screen.Title);
    }

    #endregion
  }
}
