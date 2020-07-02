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

namespace Richasy.Controls.UWP.Interaction
{
    public sealed partial class IconButton : ExtraButton
    {
        public IconButton()
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
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(IconButton), new PropertyMetadata(null,new PropertyChangedCallback(Icon_Changed)));


        private static void Icon_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as IconButton;
            if (e.NewValue != null && e.NewValue is IconElement icon)
            {
                instance.IconBlock.Visibility = Visibility.Visible;
            }
            else
            {
                instance.IconBlock.Visibility = Visibility.Collapsed;
            }
        }


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(IconButton), new PropertyMetadata(""));


        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(IconButton), new PropertyMetadata(false, new PropertyChangedCallback(IsLoading_Changed)));

        private static void IsLoading_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as IconButton;
            if (e.NewValue != e.OldValue && e.NewValue is bool isload)
            {
                if (isload)
                {
                    instance.IsEnabled = false;
                    instance.IconBlock.Visibility = Visibility.Collapsed;
                    instance.LoadingRing.Visibility = Visibility.Visible;
                }
                else
                {
                    instance.IsEnabled = true;
                    instance.LoadingRing.Visibility = Visibility.Collapsed;
                    if (instance.Icon!=null)
                        instance.IconBlock.Visibility = Visibility.Visible;
                }
            }
        }

        public double GutterWidth
        {
            get { return (double)GetValue(GutterWidthProperty); }
            set { SetValue(GutterWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GutterWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GutterWidthProperty =
            DependencyProperty.Register("GutterWidth", typeof(double), typeof(IconButton), new PropertyMetadata(6.0,new PropertyChangedCallback(GutterWidth_Changed)));

        private static void GutterWidth_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue is double width)
            {
                var instance = d as IconButton;
                instance.IconBlock.Margin = new Thickness(0, 0, width, 0);
                instance.LoadingRing.Margin= new Thickness(0, 0, width, 0);
            }
        }

        public Style TextStyle
        {
            get { return (Style)GetValue(TextStyleProperty); }
            set { SetValue(TextStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextStyleProperty =
            DependencyProperty.Register("TextStyle", typeof(Style), typeof(IconButton), new PropertyMetadata(null,new PropertyChangedCallback(TextStyle_Changed)));

        private static void TextStyle_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue is Style style)
            {
                var instance = d as IconButton;
                instance.NameTextBlock.Style = style;
            }
        }

        public Style ProgressRingStyle
        {
            get { return (Style)GetValue(ProgressRingStyleProperty); }
            set { SetValue(ProgressRingStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressRingStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressRingStyleProperty =
            DependencyProperty.Register("ProgressRingStyle", typeof(Style), typeof(IconButton), new PropertyMetadata(null));


    }
}
