using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Oculus_Test.Malcolms;
using Oculus_Test.OculusActions;

namespace Oculus_Test
{
  /// <summary>
  ///     Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private string _dllVersion;
    private Keyboard _keyboard;

    public MainWindow()
    {
      InitializeComponent();
      _dllVersion = "None";
      _keyboard = new Keyboard();
    }

    private void LoadOldDll_OnClick(object sender, RoutedEventArgs e)
    {
      _dllVersion = "Old";
      MalcolmPerformer("DllVersion", _dllVersion, LoadedDll);
    }

    private void LoadNewDll_OnClick(object sender, RoutedEventArgs e)
    {
      _dllVersion = "New";
      MalcolmPerformer("DllVersion", _dllVersion, LoadedDll);
      }
    }

    private void EyeHeight_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer("EyeHeight", _dllVersion, ShowEyeHeight);
    }

    private void EyeWidth_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer("EyeWidth", _dllVersion, ShowEyeWidth);
    }

    private void Tracking_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer("Tracking", _dllVersion, ShowTracking);
    }

    private void Init_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer("Init", _dllVersion, ShowInitStatus);
    }

    private void Proceed_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer("Proceed", _dllVersion, ShowProceedStatus);
    }

    private void Release_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer("Release", _dllVersion, ShowReleaseStatus);
    }

    private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
    {
      _keyboard.ActionFor(e.Key);
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
