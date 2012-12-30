using System;
using System.Collections.Generic;

namespace GameEngine
{
  public enum Event
  {
    KeyPressed,
    KeyReleased,
    MouseMoved,
    MouseButtonPressed,
    MouseButtonReleased,
    MouseWheelMoved,
    LeftMouseDown,
    RightMouseDown,
    MiddleMouseDown,
    LeftMouseClick,
    RightMouseClick,
    MiddleMouseClick,
    ScrollDown,
    ScrollUp,
    KeyClick,
    KeyDown,
    KeyUp,
    JoystickButtonPressed,
    JoystickButtonReleased,
    JoystickConnected,
    JoystickDisconnected,
    JoystickMoved,
    JoystickBtnDown,
    JoystickBtnUp,
    JoystickBtnClick,
    JoystickMoveLeft,
    JoystickMoveRight,
    JoystickMoveUp,
    JoystickMoveDown,
    NextWorld,
    Left,
    Right,
    Up,
    Down,
    NoDirectionalDown
  }

  /// <summary>
  /// Event Management
  /// 
  /// Registers, Deregisters and Notifies events
  /// </summary>
  public class EventManager
  {
    public delegate void MyDelegate<T>(T i);
    static Dictionary<Event, DelegateList<object>> events = new Dictionary<Event, DelegateList<object>>();

    /// <summary>
    /// Custom class to store delegates in a list
    /// </summary>
    public class DelegateList<T>
    {
      public void Add(MyDelegate<T> del)
      {
        list.Add(del);
      }

      public void CallDelegates(T param)
      {
        foreach (MyDelegate<T> del in list)
          del(param);
      }

      public bool Contains(MyDelegate<T> del)
      {
        foreach (MyDelegate<T> d in list)
          if (d.Equals(del))
            return true;

        return false;
      }

      public void Remove(MyDelegate<T> del)
      {
        int location = -1;

        for (int i = 0; i < list.Count; i++)
        {
          if (list[i].Equals(del))
          {
            location = i;
            break;
          }
        }

        if (location != -1)
          list.RemoveAt(location);
      }

      public int Count
      {
        get { return list.Count; }
      }

      private List<MyDelegate<T>> list = new List<MyDelegate<T>>();
    }

    /// <summary>
    /// Check if the key exists.
    /// If TRUE, check if method exists in list of delegates
    /// If FALSE, then add key and new delegates list
    /// </summary>
    public void Register(Event key, MyDelegate<object> method)
    {
      if (events.ContainsKey(key))
      {
        //Game1.trace(this, "Found key. " + key);
        if (!events[key].Contains(method))
        {
          //Game1.trace(this, "Found key. Add to list." + key);
          events[key].Add(method);
        }
      }
      else
      {
        //Game1.trace(this, "No key found. " + key);
        DelegateList<object> listOfDelegates = new DelegateList<object>();
        listOfDelegates.Add(method);
        events.Add(key, listOfDelegates);

      }
    }

    /// <summary>
    /// Removes method from events lists.
    /// If value (list) contains no elements, delete key from dictionary
    /// </summary>
    public void Deregister(Event key, MyDelegate<object> method)
    {
      if (events.ContainsKey(key))
      {
        if (events[key].Contains(method))
          events[key].Remove(method);

        if (events[key].Count == 0)
          events.Remove(key);
      }
    }

    public void Notify(Event key, object param)
    {
      if (events.ContainsKey(key))
        events[key].CallDelegates(param);

      // Game1.Trace(this, "Notify " + key);
    }

    public void ClearAllEvents()
    {
      // TODO: Clear all events
    }

  }
}