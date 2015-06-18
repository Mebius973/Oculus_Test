using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Oculus_Test.OculusActions;

namespace Oculus_Test
{
  /// <summary>
  ///     Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      _dllVersion = "None";
    }

    private string _dllVersion;

    private void LoadOldDll_OnClick(object sender, RoutedEventArgs e)
    {
      _dllVersion = "Old";
      var oculusAction = new OculusAction(_dllVersion);
      if (oculusAction.IsDllLoad())
      {
        LoadedDll.Text = _dllVersion;
      }
    }

    private void LoadNewDll_OnClick(object sender, RoutedEventArgs e)
    {
      _dllVersion = "New";
      var oculusAction = new OculusAction(_dllVersion);
      if (oculusAction.IsDllLoad())
      {
        LoadedDll.Text = _dllVersion;
      }
    }

    private void EyeHeight_OnClick(object sender, RoutedEventArgs e)
    {
      var eyeHeight = new EyeHeight(_dllVersion);
      ShowEyeHeight.Inlines.Add(new Run("\n       "));
      ShowEyeHeight.Inlines.Add(new Run(eyeHeight.Show()));
    }

    private void EyeWidth_OnClick(object sender, RoutedEventArgs e)
    {
      var eyeWidth = new EyeWidth(_dllVersion);
      ShowEyeHeight.Inlines.Add(new Run("\n       "));
      ShowEyeHeight.Inlines.Add(new Run(eyeWidth.Show()));
    }

    private void Tracking_OnClick(object sender, RoutedEventArgs e)
    {
      var tracking = new Tracking(_dllVersion);
      ShowEyeHeight.Inlines.Add(new Run("\n       "));
      ShowEyeHeight.Inlines.Add(new Run(tracking.Show()));
    }

    private void Init_OnClick(object sender, RoutedEventArgs e)
    {
      var init = new Init(_dllVersion);
      ShowEyeHeight.Inlines.Add(new Run("\n       "));
      ShowEyeHeight.Inlines.Add(new Run(init.Show()));
    }

    private void Proceed_OnClick(object sender, RoutedEventArgs e)
    {
      var proceed = new Proceed(_dllVersion);
      ShowEyeHeight.Inlines.Add(new Run("\n       "));
      ShowEyeHeight.Inlines.Add(new Run(proceed.Show()));
    }

    private void Release_OnClick(object sender, RoutedEventArgs e)
    {
      var release = new Release(_dllVersion);
      ShowEyeHeight.Inlines.Add(new Run("\n       "));
      ShowEyeHeight.Inlines.Add(new Run(release.Show()));
    }

    private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Escape)
      {
        Application.Current.Shutdown();
      }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}