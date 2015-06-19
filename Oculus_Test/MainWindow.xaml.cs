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
      var display = new MalcolmDllVersion(_dllVersion, LoadedDll);
      display.Update();
    }

    private void LoadNewDll_OnClick(object sender, RoutedEventArgs e)
    {
      _dllVersion = "New";
      var display = new MalcolmDllVersion(_dllVersion, LoadedDll);
      display.Update();
      }
    }

    private void EyeHeight_OnClick(object sender, RoutedEventArgs e)
    {
      var display = new MalcolmEyeHeight(_dllVersion, ShowEyeHeight);
        display.Update();
    }

    private void EyeWidth_OnClick(object sender, RoutedEventArgs e)
    {
      var display = new MalcolmEyeWidth(_dllVersion, ShowEyeWidth);
      display.Update();
    }

    private void Tracking_OnClick(object sender, RoutedEventArgs e)
    {
      var display = new MalcolmTracking(_dllVersion, ShowTracking);
      display.Update();
    }

    private void Init_OnClick(object sender, RoutedEventArgs e)
    {
      var display = new MalcolmInit(_dllVersion, ShowInitStatus);
      display.Update();
    }

    private void Proceed_OnClick(object sender, RoutedEventArgs e)
    {
      var display = new MalcolmProceed(_dllVersion, ShowProceedStatus);
      display.Update();
    }

    private void Release_OnClick(object sender, RoutedEventArgs e)
    {
      var display = new MalcolmRelease(_dllVersion, ShowReleaseStatus);
      display.Update();
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
