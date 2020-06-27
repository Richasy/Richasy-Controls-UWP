using Richasy.Controls.UWP.Extensions;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SampleApp.Pages.Interaction
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ButtonPage : Richasy.Controls.UWP.Models.UI.RichasyPage
    {
        public ButtonPage()
        {
            this.InitializeComponent();
        }

        private async void IconButton_Click(object sender, RoutedEventArgs e)
        {
            IconButton.IsLoading = true;
            await Task.Delay(2000);
            IconButton.IsLoading = false;
        }
    }
}
