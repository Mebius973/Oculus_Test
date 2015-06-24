using System.Windows;
using System.Windows.Input;

namespace Oculus_Test.Utils
{
  public static class Keyboard
  {
    public static void ActionFor(Key key)
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
