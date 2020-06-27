using Richasy.Controls.UWP.Models.UI;
using Richasy.Controls.UWP.Popups;
using SampleApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SampleApp.Pages.Popups
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TipPopupPage : RichasyPage
    {
        public TipPopupPage()
        {
            this.InitializeComponent();
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            var popup = new TipPopup(App._instance, "测试消息");
            popup.FontSize = 25;
            popup.PopupPadding = new Thickness(20);
            popup.PopupCornerRadius = new CornerRadius(15);
            popup.Show(ColorType.PrimaryColor, 3);
        }

        private void ElementButton_Click(object sender, RoutedEventArgs e)
        {
            var image = new Image();
            image.Source = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png"));
            var popup = new TipPopup(App._instance, image);
            popup.PopupMaxWidth = 100;
            popup.Show(ColorType.SecondaryColor);
        }
    }
}
