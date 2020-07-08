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

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace Richasy.Controls.UWP.Widgets
{
    public sealed partial class CenterPopupHeader : UserControl, ICenterPopupHeader
    {
        public CenterPopupHeader()
        {
            this.InitializeComponent();
        }

        public CenterPopupHeader(string title, IconElement icon, Style closeButtonStyle = null, Style titleStyle = null) : this()
        {
            Title = title;
            CloseButtonStyle = closeButtonStyle;
            CloseIcon = icon;
            TitleTextStyle = titleStyle;
        }

        public event EventHandler CloseButtonClick;

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(CenterPopupHeader), new PropertyMetadata(""));

        public Style TitleTextStyle
        {
            get { return (Style)GetValue(TitleTextStyleProperty); }
            set { SetValue(TitleTextStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleTextStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleTextStyleProperty =
            DependencyProperty.Register("TitleTextStyle", typeof(Style), typeof(CenterPopupHeader), new PropertyMetadata(null));

        /// <summary>
        /// ActionButton Style
        /// </summary>
        public Style CloseButtonStyle
        {
            get { return (Style)GetValue(CloseButtonStyleProperty); }
            set { SetValue(CloseButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseButtonStyleProperty =
            DependencyProperty.Register("CloseButtonStyle", typeof(Style), typeof(CenterPopupHeader), new PropertyMetadata(null));


        public IconElement CloseIcon
        {
            get { return (IconElement)GetValue(CloseIconProperty); }
            set { SetValue(CloseIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseIconProperty =
            DependencyProperty.Register("CloseIcon", typeof(IconElement), typeof(CenterPopupHeader), new PropertyMetadata(null));

        public UIElement AdditionElement
        {
            get { return (UIElement)GetValue(AdditionElementProperty); }
            set { SetValue(AdditionElementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AdditionElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AdditionElementProperty =
            DependencyProperty.Register("AdditionElement", typeof(UIElement), typeof(CenterPopupHeader), new PropertyMetadata(null, new PropertyChangedCallback(AdditionElement_Changed)));

        private static void AdditionElement_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue is UIElement element)
            {
                var instance = d as CenterPopupHeader;
                instance.AdditionPresenter.Visibility = Visibility.Visible;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
