using System;
using System.Windows;
using System.Windows.Documents;
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
        }

        private void EyeHeight_OnClick(object sender, RoutedEventArgs e)
        {
            var eyeHeight = new EyeHeight();
            ShowEyeHeight.Inlines.Add(new Run("\n       "));
            ShowEyeHeight.Inlines.Add(new Run(eyeHeight.Show()));
        }

        private void EyeWidth_OnClick(object sender, RoutedEventArgs e)
        {
            var eyeWidth = new EyeWidth();
            ShowEyeHeight.Inlines.Add(new Run("\n       "));
            ShowEyeHeight.Inlines.Add(new Run(eyeWidth.Show()));
        }

        private void Tracking_OnClick(object sender, RoutedEventArgs e)
        {
            var tracking = new Tracking();
            ShowEyeHeight.Inlines.Add(new Run("\n       "));
            ShowEyeHeight.Inlines.Add(new Run(tracking.Show()));
        }

        private void Init_OnClick(object sender, RoutedEventArgs e)
        {
            var init = new Init();
            ShowEyeHeight.Inlines.Add(new Run("\n       "));
            ShowEyeHeight.Inlines.Add(new Run(init.Show()));
        }

        private void Proceed_OnClick(object sender, RoutedEventArgs e)
        {
            var proceed = new Proceed();
            ShowEyeHeight.Inlines.Add(new Run("\n       "));
            ShowEyeHeight.Inlines.Add(new Run(proceed.Show()));
        }

        private void Release_OnClick(object sender, RoutedEventArgs e)
        {
            var release = new Release();
            ShowEyeHeight.Inlines.Add(new Run("\n       "));
            ShowEyeHeight.Inlines.Add(new Run(release.Show()));
        }
    }
}