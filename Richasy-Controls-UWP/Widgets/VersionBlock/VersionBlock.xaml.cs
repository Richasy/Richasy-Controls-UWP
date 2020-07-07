using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
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

namespace Richasy.Controls.UWP.Widgets
{
    public sealed partial class VersionBlock : UserControl
    {
        public static string Version = string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
        public VersionBlock()
        {
            this.InitializeComponent();
            VersionTextBlock.Text = Version;
        }
        public event EventHandler ActionButtonClick;
        public string LogoUri
        {
            get { return (string)GetValue(LogoUriProperty); }
            set { SetValue(LogoUriProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LogoUri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LogoUriProperty =
            DependencyProperty.Register("LogoUri", typeof(string), typeof(VersionBlock), new PropertyMetadata(""));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(VersionBlock), new PropertyMetadata(""));

        public Style TitleTextStyle
        {
            get { return (Style)GetValue(TitleTextStyleProperty); }
            set { SetValue(TitleTextStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleTextStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleTextStyleProperty =
            DependencyProperty.Register("TitleTextStyle", typeof(Style), typeof(VersionBlock), new PropertyMetadata(null, new PropertyChangedCallback(TitleTextStyle_Changed)));

        private static void TitleTextStyle_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue is Style style)
            {
                var instance = d as VersionBlock;
                instance.TitleBlock.Style = style;
            }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(VersionBlock), new PropertyMetadata(""));

        public Style DescriptionTextStyle
        {
            get { return (Style)GetValue(DescriptionTextStyleProperty); }
            set { SetValue(DescriptionTextStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DescriptionTextStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionTextStyleProperty =
            DependencyProperty.Register("DescriptionTextStyle", typeof(Style), typeof(VersionBlock), new PropertyMetadata(null));

        public Style ScrollViewerStyle
        {
            get { return (Style)GetValue(ScrollViewerStyleProperty); }
            set { SetValue(ScrollViewerStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScrollViewerStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollViewerStyleProperty =
            DependencyProperty.Register("ScrollViewerStyle", typeof(Style), typeof(VersionBlock), new PropertyMetadata(null));

        public Style ActionButtonStyle
        {
            get { return (Style)GetValue(ActionButtonStyleProperty); }
            set { SetValue(ActionButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActionButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionButtonStyleProperty =
            DependencyProperty.Register("ActionButtonStyle", typeof(Style), typeof(VersionBlock), new PropertyMetadata(null));

        public Style VersionTextStyle
        {
            get { return (Style)GetValue(VersionTextStyleProperty); }
            set { SetValue(VersionTextStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VersionTextStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VersionTextStyleProperty =
            DependencyProperty.Register("VersionTextStyle", typeof(Style), typeof(VersionBlock), new PropertyMetadata(null, new PropertyChangedCallback(VersionTextStyle_Changed)));

        private static void VersionTextStyle_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue is Style style)
            {
                var instance = d as VersionBlock;
                instance.VersionTextBlock.Style = style;
            }
        }

        public IconElement ActionIcon
        {
            get { return (IconElement)GetValue(ActionIconProperty); }
            set { SetValue(ActionIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActionIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionIconProperty =
            DependencyProperty.Register("ActionIcon", typeof(IconElement), typeof(VersionBlock), new PropertyMetadata(null));

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ActionButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
