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

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace Richasy.Controls.UWP.Widgets
{
    public sealed partial class IconTextBlock : UserControl
    {
        public IconTextBlock()
        {
            this.InitializeComponent();
        }


        public IconElement Icon
        {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(IconTextBlock), new PropertyMetadata(null));



        public GridLength GutterWidth
        {
            get { return (GridLength)GetValue(GutterWidthProperty); }
            set { SetValue(GutterWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GutterWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GutterWidthProperty =
            DependencyProperty.Register("GutterWidth", typeof(GridLength), typeof(IconTextBlock), new PropertyMetadata(new GridLength(10)));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(IconTextBlock), new PropertyMetadata(""));

        public bool IsTextSelectionEnabled
        {
            get { return (bool)GetValue(IsTextSelectionEnabledProperty); }
            set { SetValue(IsTextSelectionEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsTextSelectionEnable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTextSelectionEnabledProperty =
            DependencyProperty.Register("IsTextSelectionEnabled", typeof(bool), typeof(IconTextBlock), new PropertyMetadata(false));

    }
}
