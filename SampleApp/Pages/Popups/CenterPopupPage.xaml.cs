using Richasy.Controls.UWP.Popups;
using SampleApp.Controls;
using SampleApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SampleApp.Pages.Popups
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CenterPopupPage : Page
    {

        public CenterPopupPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var header = new CenterPopupHeader();
            var main = new Grid();
            var rect = new Rectangle() { Width = 300, Height = 300, Fill = new SolidColorBrush(Colors.Gray) };
            main.Children.Add(rect);
            var popup = CenterPopup.CreatePopup(App._instance, header, main, ColorType.MaskAcrylicBackground, ColorType.PageBackground, 468, double.NaN);
            popup.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
