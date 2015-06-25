using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Oculus_Test.Utils;

namespace Oculus_Test
{
  /// <summary>
  ///     Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    private string _dllVersion;
    private static TextBlock _field;
    private string _action;

    public MainWindow()
    {
      InitializeComponent();
      _dllVersion = "None";
    }

    private void LoadOldDll_OnClick(object sender, RoutedEventArgs e)
    {
      Console.WriteLine(sender);
      Console.WriteLine(e);
      _dllVersion = "Old";
      _field = LoadedDll;
      _action = "DllVersion";
      MalcolmPerformer.For(_action, _dllVersion, _field);
    }

    private void LoadNewDll_OnClick(object sender, RoutedEventArgs e)
    {
      _dllVersion = "New";
      _field = LoadedDll;
      _action = "DllVersion";
      MalcolmPerformer.For(_action, _dllVersion, _field);
    }

    private void EyeHeight_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowEyeHeight;
      _action = "EyeHeight";
      MalcolmPerformer.For(_action, _dllVersion, _field);
    }

    private void EyeWidth_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowEyeWidth;
      _action = "EyeWidth";
      MalcolmPerformer.For(_action, _dllVersion, _field);
    }

    private void Tracking_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowTracking;
      _action = "Tracking";
      MalcolmPerformer.For(_action, _dllVersion, _field);
    }

    private void Init_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowInitStatus;
      _action = "Init";
      MalcolmPerformer.For(_action, _dllVersion, _field);
    }

    private void Proceed_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowProceedStatus;
      _action = "Proceed";
      MalcolmPerformer.For(_action, _dllVersion, _field);
    }

    private void Release_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowReleaseStatus;
      _action = "Release";
      MalcolmPerformer.For(_action, _dllVersion, _field);
    }

    private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.Key)
      {
        case Key.Escape:
          Application.Current.Shutdown();
          break;
        case Key.C:
          Application.Current.Shutdown();
          break;
        case Key.O:
          LoadOldDll_OnClick(null, null);
          break;
        case Key.N:
          LoadNewDll_OnClick(null, null);
          break;
        case Key.H:
          EyeHeight_OnClick(null, null);
          break;
        case Key.W:
          EyeWidth_OnClick(null, null);
          break;
        case Key.T:
          Tracking_OnClick(null, null);
          break;
        case Key.I:
          Init_OnClick(null, null);
          break;
        case Key.P:
          Proceed_OnClick(null, null);
          break;
        case Key.R:
          Release_OnClick(null, null);
          break;
      }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
