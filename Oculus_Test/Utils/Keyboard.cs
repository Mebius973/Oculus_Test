using System.Windows;
using System.Windows.Input;

namespace Oculus_Test.Utils
{
  public class Keyboard : MainWindow
  {
    public static void ActionFor(Key key)
    {
      switch (key)
      {
        case Key.Escape:
          Application.Current.Shutdown();
          break;
        case Key.O:
          
          break;
        case Key.N:
          break;
        case Key.H:
          break;
        case Key.W:
          break;
        case Key.T:
          break;
        case Key.I:
          break;
        case Key.P:
          break;
        case Key.R:
          break;
      }
    }
  }
}