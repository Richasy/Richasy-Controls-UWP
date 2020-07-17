using Richasy.Controls.UWP.Popups;
using SampleApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace SampleApp.Pages.Popups
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class WaitingPopupPage : Page
    {
        public WaitingPopupPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var popup = new WaitingPopup(App._instance);
            popup.PopupBackground = App._instance.App.GetThemeBrushFromResource(ColorType.MaskAcrylicBackground);
            popup.PresenterBackground = App._instance.App.GetThemeBrushFromResource(ColorType.PageBackground);
            popup.CornerRadius = new CornerRadius(8);
            popup.PopupMaxWidth = 150;
            popup.PopupMaxHeight = 150;
            popup.Text = "等待中...";
            popup.TextStyle = DefaultTextStyle;
            popup.ProgressRingStyle = DefaultProgressRing;
            popup.Show();
            await Task.Delay(2000);
            popup.Hide();
        }
    }
}
