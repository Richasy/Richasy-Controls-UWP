using Richasy.Helper.UWP;
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

namespace Richasy.Controls.UWP.Popups
{
    public sealed partial class WaitingPopup : UserControl
    {
        private Popup _popup = null;
        private Guid _guid;
        public Action<Size> WindowSizeChangedHandle { get; set; }
        public WaitingPopup()
        {
            this.InitializeComponent();
            _guid = Guid.NewGuid();
            this.Width = Window.Current.Bounds.Width;
            this.Height = Window.Current.Bounds.Height;
            _popup = new Popup();
            _popup.Child = this;
        }
        public WaitingPopup(Instance instance) : this()
        {
            Instance = instance;
        }
        public Instance Instance { get; set; }
        public Brush PopupBackground
        {
            get { return (Brush)GetValue(PopupBackgroundProperty); }
            set { SetValue(PopupBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupBackgroundProperty =
            DependencyProperty.Register("PopupBackground", typeof(Brush), typeof(WaitingPopup), new PropertyMetadata(null));

        public Brush PresenterBackground
        {
            get { return (Brush)GetValue(PresenterBackgroundProperty); }
            set { SetValue(PresenterBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PresenterBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PresenterBackgroundProperty =
            DependencyProperty.Register("PresenterBackground", typeof(Brush), typeof(WaitingPopup), new PropertyMetadata(null));
        public double PopupMaxWidth
        {
            get { return (double)GetValue(PopupMaxWidthProperty); }
            set { SetValue(PopupMaxWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupMaxWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupMaxWidthProperty =
            DependencyProperty.Register("PopupMaxWidth", typeof(double), typeof(WaitingPopup), new PropertyMetadata(double.NaN));

        public double PopupMaxHeight
        {
            get { return (double)GetValue(PopupMaxHeightProperty); }
            set { SetValue(PopupMaxHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupMaxHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupMaxHeightProperty =
            DependencyProperty.Register("PopupMaxHeight", typeof(double), typeof(WaitingPopup), new PropertyMetadata(double.NaN));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WaitingPopup), new PropertyMetadata(""));

        public Style TextStyle
        {
            get { return (Style)GetValue(TextStyleProperty); }
            set { SetValue(TextStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextStyleProperty =
            DependencyProperty.Register("TextStyle", typeof(Style), typeof(WaitingPopup), new PropertyMetadata(null));

        public Style ProgressRingStyle
        {
            get { return (Style)GetValue(ProgressRingStyleProperty); }
            set { SetValue(ProgressRingStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressRingStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressRingStyleProperty =
            DependencyProperty.Register("ProgressRingStyle", typeof(Style), typeof(WaitingPopup), new PropertyMetadata(null));


        /// <summary>
        /// 显示弹出层
        /// </summary>
        public void Show()
        {
            Instance.AddWindowSizeChangeAction(_guid, (size) =>
            {
                Width = size.Width;
                Height = size.Height;
                WindowSizeChangedHandle?.Invoke(size);
            });
            WindowSizeChangedHandle?.Invoke(new Size(Window.Current.Bounds.Width, Window.Current.Bounds.Height));
            PopupContainer.Visibility = Visibility.Visible;
            DisplayContainer.Visibility = Visibility.Visible;
            _popup.IsOpen = true;
        }
        /// <summary>
        /// 隐藏弹出层
        /// </summary>
        public void Hide()
        {
            PopupContainer.Visibility = Visibility.Collapsed;
            DisplayContainer.Visibility = Visibility.Collapsed;
            _popup.IsOpen = false;
            Instance.RemoveWindowSizeChangeAction(_guid);
        }
    }
}
