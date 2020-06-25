using Richasy.Controls.UWP.Models.Interface;
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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace SampleApp.Controls
{
    public sealed partial class CenterPopupHeader : UserControl,ICenterPopupHeader
    {
        public CenterPopupHeader()
        {
            this.InitializeComponent();
        }

        public event EventHandler CloseButtonClick;

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
