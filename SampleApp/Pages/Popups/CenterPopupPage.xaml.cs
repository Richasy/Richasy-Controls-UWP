using Richasy.Controls.UWP.Models.UI;
using Richasy.Controls.UWP.Popups;
using Richasy.Controls.UWP.Widgets;
using SampleApp.Models.Enum;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SampleApp.Pages.Popups
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CenterPopupPage : RichasyPage
    {

        public CenterPopupPage()
        {
            this.InitializeComponent();
            IsInit = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var header = HeaderTemplate.LoadContent() as CenterPopupHeader;
            var main = new Grid();
            var rect = new Rectangle() { Width = 300, Height = 300, Fill = new SolidColorBrush(Colors.Gray) };
            main.Children.Add(rect);
            var popup = CenterPopup.CreatePopup(App._instance, header, main, ColorType.MaskAcrylicBackground, ColorType.PageBackground, 468, double.NaN);
            popup.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var main = UpdateTemplate.LoadContent() as VersionBlock;
            var popup = new CenterPopup(App._instance);
            popup.Main = main;
            popup.PresenterBackground = App._instance.App.GetThemeBrushFromResource(ColorType.CardBackground);
            popup.PopupBackground = App._instance.App.GetThemeBrushFromResource(ColorType.MaskAcrylicBackground);
            popup.PopupMaxWidth = 400;
            popup.CornerRadius = new CornerRadius(4);
            main.ActionButtonClick += (_s, _e) =>
            {
                popup.Hide();
            };
            popup.Show();
        }
    }
}
