using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Oculus_Test.Utils;

namespace Oculus_Test
{
  /// <summary>
  ///     Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    private string _dllVersion;
    private string _imageMode;
    private static TextBlock _field;
    private string _action;
    private static BitmapImage LeftEyeBitmapImage { get; set; }
    private static BitmapImage RightEyeBitmapImage { get; set; }

    public MainWindow()
    {
      InitializeComponent();
      _dllVersion = "None";
      _imageMode = "None";
    }

    public static void SetLeftEyeImage(byte[] rawImg)
    {
      var image = new BitmapImage();
      using (var mem = new MemoryStream(rawImg))
      {
        mem.Position = 0;
        image.BeginInit();
        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.UriSource = null;
        image.StreamSource = mem;
        image.EndInit();
      }
      image.Freeze();
      LeftEyeBitmapImage = image;
    }

    public static void SetRightEyeImage(byte[] rawImg)
    {
      var image = new BitmapImage();
      using (var mem = new MemoryStream(rawImg))
      {
        mem.Position = 0;
        image.BeginInit();
        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.UriSource = null;
        image.StreamSource = mem;
        image.EndInit();
      }
      image.Freeze();
      RightEyeBitmapImage = image;
    }

    private void LoadOldDll_OnClick(object sender, RoutedEventArgs e)
    {
      Console.WriteLine(sender);
      Console.WriteLine(e);
      _dllVersion = "Old";
      _field = LoadedDll;
      _action = "DllVersion";
      MalcolmPerformer.For(_action, _dllVersion, _imageMode, _field);
    }

    private void LoadNewDll_OnClick(object sender, RoutedEventArgs e)
    {
      _dllVersion = "New";
      _field = LoadedDll;
      _action = "DllVersion";
      MalcolmPerformer.For(_action, _dllVersion, _imageMode, _field);
    }

    private void MonoMode_OnClick(object sender, RoutedEventArgs e)
    {
      _imageMode = "Mono";
      ImageStreamingMode.Text = _imageMode;
    }

    private void DualMode_OnClick(object sender, RoutedEventArgs e)
    {
      _imageMode = "Dual";
      ImageStreamingMode.Text = _imageMode;
    }

    private void EyeHeight_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowEyeHeight;
      _action = "EyeHeight";
      MalcolmPerformer.For(_action, _dllVersion, _imageMode, _field);
    }

    private void EyeWidth_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowEyeWidth;
      _action = "EyeWidth";
      MalcolmPerformer.For(_action, _dllVersion, _imageMode, _field);
    }

    private void Tracking_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowTracking;
      _action = "Tracking";
      MalcolmPerformer.For(_action, _dllVersion, _imageMode, _field);
    }

    private void Init_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowInitStatus;
      _action = "Init";
      MalcolmPerformer.For(_action, _dllVersion, _imageMode, _field);
    }

    private void Proceed_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowProceedStatus;
      _action = "Proceed";
      MalcolmPerformer.For(_action, _dllVersion, _imageMode, _field);
      LeftEyeImage.Source = LeftEyeBitmapImage;
      RightEyeImage.Source = RightEyeBitmapImage;
    }

    private void Release_OnClick(object sender, RoutedEventArgs e)
    {
      _field = ShowReleaseStatus;
      _action = "Release";
      MalcolmPerformer.For(_action, _dllVersion, _imageMode, _field);
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
        case Key.M:
          MonoMode_OnClick(null, null);
          break;
        case Key.D:
          DualMode_OnClick(null, null);
          break;
      }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
