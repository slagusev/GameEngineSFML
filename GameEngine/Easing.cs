using System;

namespace GameEngine
{
  class Easing
  {
    /// <summary>
    /// Source: http://timotheegroleau.com/Flash/experiments/easing_function_generator.htm
    /// </summary>
    public enum Transition
    {
      Linear, InOutCubic, InOutQuintic, InQuintic, InQuartic, InCubic, InQuadratic,
      OutQuintic, OutQuartic, OutCubic, OutInCubic, OutInQuartic,
      BackInCubic, BackInQuartic, OutBackCubic, OutBackQuartic,
      OutElasticSmall, OutElasticBig, InElasticSmall, InElasticBig
    }

    public static float Ease(Transition transition, float time, float origin, float dest, float duration)
    {
      switch (transition)
      {
        case Transition.Linear:
          return Linear(time, origin, dest, duration);
        case Transition.InOutCubic:
          return InOutCubic(time, origin, dest, duration);
        case Transition.InOutQuintic:
          return InOutQuintic(time, origin, dest, duration);
        case Transition.InQuintic:
          return InQuintic(time, origin, dest, duration);
        case Transition.InQuartic:
          return InQuartic(time, origin, dest, duration);
        case Transition.InCubic:
          return InCubic(time, origin, dest, duration);
        case Transition.InQuadratic:
          return InQuadratic(time, origin, dest, duration);
        case Transition.OutQuintic:
          return OutQuintic(time, origin, dest, duration);
        case Transition.OutQuartic:
          return OutQuartic(time, origin, dest, duration);
        case Transition.OutCubic:
          return OutCubic(time, origin, dest, duration);
        case Transition.OutInCubic:
          return OutInCubic(time, origin, dest, duration);
        case Transition.OutInQuartic:
          return OutInQuartic(time, origin, dest, duration);
        case Transition.BackInCubic:
          return BackInCubic(time, origin, dest, duration);
        case Transition.BackInQuartic:
          return BackInQuartic(time, origin, dest, duration);
        case Transition.OutBackCubic:
          return OutBackCubic(time, origin, dest, duration);
        case Transition.OutBackQuartic:
          return OutBackQuartic(time, origin, dest, duration);
        case Transition.OutElasticSmall:
          return OutElasticSmall(time, origin, dest, duration);
        case Transition.OutElasticBig:
          return OutElasticBig(time, origin, dest, duration);
        case Transition.InElasticSmall:
          return InElasticSmall(time, origin, dest, duration);
        case Transition.InElasticBig:
          return InElasticBig(time, origin, dest, duration);
        default:
          return Linear(time, origin, dest, duration);
      }
    }

    private static float Linear(float time, float origin, float dest, float duration)
    {
      time /= duration;
      return origin + (dest - origin) * (time);
    }

    private static float InOutCubic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (-2 * timeCurrent + 3 * timeSlice);
    }

    private static float InOutQuintic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (6 * timeCurrent * timeSlice + -15 * timeSlice * timeSlice + 10 * timeCurrent);
    }

    private static float InQuintic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (timeCurrent * timeSlice);
    }

    private static float InQuartic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      return origin + (dest - origin) * (timeSlice * timeSlice);
    }

    private static float InCubic(float time, float origin, float dest, float duration)
    {
      float timeCurrent = (time /= duration) * time * time;
      return origin + (dest - origin) * (timeCurrent);
    }

    private static float InQuadratic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      return origin + (dest - origin) * (timeSlice);
    }

    private static float OutQuintic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (timeCurrent * timeSlice + -5 * timeSlice * timeSlice + 10 * timeCurrent + -10 * timeSlice + 5 * time);
    }

    private static float OutQuartic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (-1 * timeSlice * timeSlice + 4 * timeCurrent + -6 * timeSlice + 4 * time);
    }

    private static float OutCubic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (timeCurrent + -3 * timeSlice + 3 * time);
    }

    private static float OutInCubic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (4 * timeCurrent + -6 * timeSlice + 3 * time);
    }

    private static float OutInQuartic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (6 * timeCurrent + -9 * timeSlice + 4 * time);
    }

    private static float BackInCubic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (4 * timeCurrent + -3 * timeSlice);
    }

    private static float BackInQuartic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (2 * timeSlice * timeSlice + 2 * timeCurrent + -3 * timeSlice);
    }

    private static float OutBackCubic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (4 * timeCurrent + -9 * timeSlice + 6 * time);
    }

    private static float OutBackQuartic(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (-2 * timeSlice * timeSlice + 10 * timeCurrent + -15 * timeSlice + 8 * time);
    }

    private static float OutElasticSmall(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;

      // Original Version
      // return origin + (dest - origin) * (33 * timeCurrent * timeSlice + -106 * timeSlice * timeSlice + 126 * timeCurrent + -67 * timeSlice + 15 * time);

      // Slightly weaker version
      return origin + (dest - origin) * (31.75f * timeCurrent * timeSlice + -101 * timeSlice * timeSlice + 118.5f * timeCurrent + -62 * timeSlice + 13.75f * time);
    }

    private static float OutElasticBig(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (56 * timeCurrent * timeSlice + -175 * timeSlice * timeSlice + 200 * timeCurrent + -100 * timeSlice + 20 * time);
    }

    private static float InElasticSmall(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (33 * timeCurrent * timeSlice + -59 * timeSlice * timeSlice + 32 * timeCurrent + -5 * timeSlice);
    }

    private static float InElasticBig(float time, float origin, float dest, float duration)
    {
      float timeSlice = (time /= duration) * time;
      float timeCurrent = timeSlice * time;
      return origin + (dest - origin) * (56 * timeCurrent * timeSlice + -105 * timeSlice * timeSlice + 60 * timeCurrent + -10 * timeSlice);
    }
  }
}
