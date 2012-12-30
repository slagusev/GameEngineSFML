using System;
using System.Collections.Generic;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine.Splash
{
  class Controller : AController
  {
    public List<Ball> Balls;
    Ball playerBall;

    public Controller()
    {
      Balls = new List<Ball>();
      Balls.Add(new Ball(100, 100, 20, Color.Green));

      playerBall = new Ball(100, 100, 50, Color.Magenta);
      playerBall.Velocity = new Vector2f(0, 0);

      Balls.Add(playerBall);
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

    public void KeyReleased(object keyEventArgs)
    {
      KeyEventArgs keyboard = (KeyEventArgs)keyEventArgs;

      if (keyboard.Code == Keyboard.Key.Left)
        playerBall.Velocity.X = 0;
      else if (keyboard.Code == Keyboard.Key.Right)
        playerBall.Velocity.X = 0;

      if (keyboard.Code == Keyboard.Key.Up)
        playerBall.Velocity.Y = 0;
      else if (keyboard.Code == Keyboard.Key.Down)
        playerBall.Velocity.Y = 0;


    }

    public void Left(object nothing)
    {
      playerBall.Velocity.X = -1;
    }

    public void Right(object nothing)
    {
      playerBall.Velocity.X = 1;
    }

    public void Up(object nothing)
    {
      playerBall.Velocity.Y = -1;
    }

    public void Down(object nothing)
    {
      playerBall.Velocity.Y = 1;
    }

    #endregion
  }
}
