using System.Windows;
using System.Windows.Input;
using Oculus_Test.Utils;
using Keyboard = Oculus_Test.Utils.Keyboard;

namespace Oculus_Test
{
  /// <summary>
  ///     Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private string _dllVersion;

    public MainWindow()
    {
      InitializeComponent();
      _dllVersion = "None";
    }

    private void LoadOldDll_OnClick(object sender, RoutedEventArgs e)
    {
      _dllVersion = "Old";
      MalcolmPerformer.For("DllVersion", _dllVersion, LoadedDll);
    }

    private void LoadNewDll_OnClick(object sender, RoutedEventArgs e)
    {
      _dllVersion = "New";
      MalcolmPerformer.For("DllVersion", _dllVersion, LoadedDll);
    }

    private void EyeHeight_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer.For("EyeHeight", _dllVersion, ShowEyeHeight);
    }

    private void EyeWidth_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer.For("EyeWidth", _dllVersion, ShowEyeWidth);
    }

    private void Tracking_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer.For("Tracking", _dllVersion, ShowTracking);
    }

    private void Init_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer.For("Init", _dllVersion, ShowInitStatus);
    }

    private void Proceed_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer.For("Proceed", _dllVersion, ShowProceedStatus);
    }

    private void Release_OnClick(object sender, RoutedEventArgs e)
    {
      MalcolmPerformer.For("Release", _dllVersion, ShowReleaseStatus);
    }

    private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
    {
      Keyboard.ActionFor(e.Key);
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
