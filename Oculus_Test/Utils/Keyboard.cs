namespace Oculus_Test.Utils
{
  public static class Keyboard
  {
    public void ActionFor(Key key)
    {
      switch (key)
      {
        case Key.Escape:
          Application.Current.Shutdown();
          break;
      }
    }
  }
}
