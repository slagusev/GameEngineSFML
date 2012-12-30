using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace GameEngine
{
  public enum Element { Blank, Domey }
  public enum SoundElement { Tone1 }
  public enum ImageName { Nothing, Antagonist }
  public enum MusicElement { Microbia }

  #region struct Slice
  public struct Slice
  {
    public Element Element;
    public ImageName ImageName;
    public int X;
    public int Y;
    public int Width;
    public int Height;

    //public Slice()
    //{
    //  Element = Element.Blank;
    //  ImageName = ImageName.Nothing;
    //  X = 0;
    //  Y = 0;
    //  Width = 0;
    //  Height = 0;
    //}

    public Slice(Element element, ImageName imageName,
      int x, int y, int width, int height)
    {
      Element = element;
      ImageName = imageName;
      X = x;
      Y = y;
      Width = width;
      Height = height;
    }
  }
  #endregion

  #region struct ImagePath
  public struct ImagePath
  {
    public ImageName Name;
    public string Path;

    public ImagePath(ImageName imageName, string path)
    {
      Name = imageName;
      Path = path;
    }
  }
  #endregion

  #region struct AudioPath
  public struct SoundPath
  {
    public SoundElement Name;
    public string Path;

    public SoundPath(SoundElement element, string path)
    {
      Name = element;
      Path = path;
    }
  }
  #endregion

  #region struct MusicPath
  public struct MusicPath
  {
    public MusicElement Name;
    public string Path;

    public MusicPath(MusicElement element, string path)
    {
      Name = element;
      Path = path;
    }
  }
  #endregion

  public static class DAO
  {
    static string SLICES_FILENAME = @"XML/Slices.xml";
    static string IMAGES_FILENAME = @"XML/Images.xml";
    static string SOUND_FILENAME = @"XML/Sound.xml";
    static string MUSIC_FILENAME = @"XML/Music.xml";

    // Graphics
    static Dictionary<Element, Slice> Slices = new Dictionary<Element, Slice>();
    static Dictionary<ImageName, Texture> Images = new Dictionary<ImageName, Texture>();
    static Dictionary<Element, Sprite> Sprites = new Dictionary<Element, Sprite>();

    // Sound
    static Dictionary<SoundElement, SoundBuffer> SoundBuffers = new Dictionary<SoundElement, SoundBuffer>();
    static Dictionary<SoundElement, Sound> Sounds = new Dictionary<SoundElement, Sound>();

    // Music
    static Dictionary<MusicElement, Music> Musics = new Dictionary<MusicElement, Music>();

    public static Sprite GetSprite(Element element)
    {
      try
      {
        return Sprites[element];
      }
      catch { }

      return null;
    }

    public static Sound GetSound(SoundElement element)
    {
      try
      {
        return Sounds[element];
      }
      catch { }

      return null;
    }

    public static Music GetMusic(MusicElement element)
    {
      try
      {
        return Musics[element];
      }
      catch { }

      return null;
    }

    public static void GenerateTestImagesXML()
    {
      #region Slices.xml
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(Slice[]));
        TextWriter writer = new StreamWriter(SLICES_FILENAME, false);

        Slice[] slices = new Slice[] { new Slice(Element.Blank, ImageName.Nothing, 0, 0, 0, 0) };

        serializer.Serialize(writer, slices);
      }
      catch (Exception ex)
      {
        Console.WriteLine("GenerateTextXML ERROR: " + ex.Message);
      }
      #endregion

      #region ImagePaths.xml
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(ImagePath[]));
        TextWriter writer = new StreamWriter(IMAGES_FILENAME, false);

        ImagePath[] paths = new ImagePath[] { new ImagePath(ImageName.Nothing, "path.png") };

        serializer.Serialize(writer, paths);
      }
      catch (Exception ex)
      {
        Console.WriteLine("GenerateTextXML ERROR: " + ex.Message);
      }
      #endregion
    }

    public static void GenerateTestAudioXML()
    {
      #region Audio.xml
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(SoundPath[]));
        TextWriter writer = new StreamWriter(SOUND_FILENAME, false);

        SoundPath[] paths = new SoundPath[] { new SoundPath(SoundElement.Tone1, "path.ogg") };

        serializer.Serialize(writer, paths);
      }
      catch (Exception ex)
      {
        Console.WriteLine("GenerateTextXML ERROR: " + ex.Message);
      }
      #endregion

      #region Music.xml
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(MusicPath[]));
        TextWriter writer = new StreamWriter(MUSIC_FILENAME, false);

        MusicPath[] paths = new MusicPath[] { new MusicPath(MusicElement.Microbia, "microbia.ogg") };

        serializer.Serialize(writer, paths);
      }
      catch (Exception ex)
      {
        Console.WriteLine("GenerateTextXML ERROR: " + ex.Message);
      }
      #endregion
    }

    public static void LoadImages()
    {
      #region Load Slices from XML into Dictionary<Element, Slice> Slices
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(Slice[]));
        TextReader reader = new StreamReader(SLICES_FILENAME, false);

        Slice[] slices = (Slice[])serializer.Deserialize(reader);
        reader.Close();

        foreach (Slice slice in slices)
          Slices.Add(slice.Element, slice);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error loading slices: " + ex.Message);
      }
      #endregion

      #region Load Images from XML into Dictionary<Element, Texture> Images
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(ImagePath[]));
        TextReader reader = new StreamReader(IMAGES_FILENAME, false);

        ImagePath[] paths = (ImagePath[])serializer.Deserialize(reader);
        reader.Close();

        foreach (ImagePath path in paths)
        {
          Texture texture = new Texture(new Image(path.Path));
          Images.Add(path.Name, texture);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error loading images: " + ex.Message);
      }
      #endregion

      #region Match Slices and Textures and add to Dictionary<Element, Sprite> Sprites
      foreach (Slice slice in Slices.Values)
      {
        Element element = slice.Element;
        IntRect rectangle = new IntRect(slice.X, slice.Y, slice.Width, slice.Height);
        ImageName imageName = slice.ImageName;
        Texture texture = Images[imageName];
        Sprite sprite = new Sprite(texture, rectangle);

        Sprites.Add(element, sprite);
      }
      #endregion
    }

    public static void LoadSound()
    {
      #region Load Sound from XML into Dictionary<AudioElement, SoundBuffer> SoundBuffers
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(SoundPath[]));
        TextReader reader = new StreamReader(SOUND_FILENAME, false);

        SoundPath[] soundPaths = (SoundPath[])serializer.Deserialize(reader);
        reader.Close();

        foreach (SoundPath sound in soundPaths)
          SoundBuffers.Add(sound.Name, new SoundBuffer(sound.Path));
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error loading SoundPath: " + ex.Message);
      }
      #endregion

      #region Add Sound Dictionary<SoundElement, Sound> Sounds

      foreach (SoundElement element in SoundBuffers.Keys)
        Sounds.Add(element, new Sound(SoundBuffers[element]));

      #endregion
    }

    public static void LoadMusic()
    {
      try
      {
        XmlSerializer serializer = new XmlSerializer(typeof(MusicPath[]));
        TextReader reader = new StreamReader(MUSIC_FILENAME, false);

        MusicPath[] musicPaths = (MusicPath[])serializer.Deserialize(reader);
        reader.Close();

        foreach (MusicPath music in musicPaths)
          Musics.Add(music.Name, new Music(music.Path));
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error loading MusicPath: " + ex.Message);
      }

      // Music Test 
      //Music music;
      //music = new Music(@"Music/microbia.ogg");
      //music.Play();
    }
  }
}
