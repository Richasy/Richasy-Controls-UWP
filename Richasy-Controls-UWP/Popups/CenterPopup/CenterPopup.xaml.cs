using Richasy.Controls.UWP.Models.Interface;
using Richasy.Helper.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.HumanInterfaceDevice;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Richasy.Controls.UWP.Popups
{
    public partial class CenterPopup : UserControl
    {
        private Popup _popup = null;
        private Guid _guid;
        public Action<Size> WindowSizeChangedHandle { get; set; }
        public CenterPopup()
        {
            this.InitializeComponent();
            _guid = Guid.NewGuid();
            this.Width = Window.Current.Bounds.Width;
            this.Height = Window.Current.Bounds.Height;
            _popup = new Popup();
            _popup.Child = this;
        }
        public CenterPopup(Instance instance) : this()
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
            DependencyProperty.Register("PopupBackground", typeof(Brush), typeof(CenterPopup), new PropertyMetadata(null));

        public Brush PresenterBackground
        {
            get { return (Brush)GetValue(PresenterBackgroundProperty); }
            set { SetValue(PresenterBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PresenterBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PresenterBackgroundProperty =
            DependencyProperty.Register("PresenterBackground", typeof(Brush), typeof(CenterPopup), new PropertyMetadata(null));

        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShadowColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(CenterPopup), new PropertyMetadata(Colors.Black));

        public double ShadowOpacity
        {
            get { return (double)GetValue(ShadowOpacityProperty); }
            set { SetValue(ShadowOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShadowOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShadowOpacityProperty =
            DependencyProperty.Register("ShadowOpacity", typeof(double), typeof(CenterPopup), new PropertyMetadata(0.03));

        public double ShadowBlur
        {
            get { return (double)GetValue(ShadowBlurProperty); }
            set { SetValue(ShadowBlurProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShadowBlur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShadowBlurProperty =
            DependencyProperty.Register("ShadowBlur", typeof(double), typeof(CenterPopup), new PropertyMetadata(25.0));

        public ICenterPopupHeader Header
        {
            get { return (ICenterPopupHeader)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(ICenterPopupHeader), typeof(CenterPopup), new PropertyMetadata(null));

        public object Main
        {
            get { return (object)GetValue(MainProperty); }
            set { SetValue(MainProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Main.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainProperty =
            DependencyProperty.Register("Main", typeof(object), typeof(CenterPopup), new PropertyMetadata(null));

        public double PopupMaxWidth
        {
            get { return (double)GetValue(PopupMaxWidthProperty); }
            set { SetValue(PopupMaxWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupMaxWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupMaxWidthProperty =
            DependencyProperty.Register("PopupMaxWidth", typeof(double), typeof(CenterPopup), new PropertyMetadata(double.NaN));

        public double PopupMaxHeight
        {
            get { return (double)GetValue(PopupMaxHeightProperty); }
            set { SetValue(PopupMaxHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupMaxHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupMaxHeightProperty =
            DependencyProperty.Register("PopupMaxHeight", typeof(double), typeof(CenterPopup), new PropertyMetadata(double.NaN));


        public double PopupWidth
        {
            get { return (double)GetValue(PopupWidthProperty); }
            set { SetValue(PopupWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupWidthProperty =
            DependencyProperty.Register("PopupWidth", typeof(double), typeof(CenterPopup), new PropertyMetadata(double.NaN));

        public double PopupHeight
        {
            get { return (double)GetValue(PopupHeightProperty); }
            set { SetValue(PopupHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupHeightProperty =
            DependencyProperty.Register("PopupHeight", typeof(double), typeof(CenterPopup), new PropertyMetadata(double.NaN));

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

        /// <summary>
        /// 创建弹出层
        /// </summary>
        /// <param name="instance">应用帮助类注入</param>
        /// <param name="header">头部元素</param>
        /// <param name="main">主体元素</param>
        /// <param name="SizeChangedHandle">窗口大小变化时的额外处理逻辑</param>
        /// <returns></returns>
        public static CenterPopup CreatePopup(Instance instance, ICenterPopupHeader header, object main, Action<Size> SizeChangedHandle = null)
        {
            var popup = new CenterPopup();
            popup.Instance = instance;
            popup.Header = header;
            popup.Main = main;
            popup.WindowSizeChangedHandle = SizeChangedHandle;
            if (header != null)
            {
                popup.Header.CloseButtonClick += (_s, _e) =>
                {
                    popup.Hide();
                };
            }
            return popup;
        }
        /// <summary>
        /// 创建弹出层
        /// </summary>
        /// <param name="instance">应用帮助类注入</param>
        /// <param name="header">头部元素</param>
        /// <param name="main">主体元素</param>
        /// <param name="popupBackground">遮罩背景</param>
        /// <param name="presenterBackground">显示区域背景</param>
        /// <param name="maxWidth">显示区域最大宽度</param>
        /// <param name="maxHeight">显示区域最大高度</param>
        /// <param name="width">显示区域宽度，默认为<c>NaN</c></param>
        /// <param name="height">显示区域高度，默认为<c>NaN</c></param>
        /// <param name="SizeChangedHandle">窗口大小变化时的额外处理逻辑</param>
        /// <returns></returns>
        public static CenterPopup CreatePopup(Instance instance, ICenterPopupHeader header, object main, Brush popupBackground, Brush presenterBackground, double maxWidth, double maxHeight, double width = double.NaN, double height = double.NaN, Action<Size> SizeChangedHandle = null)
        {
            var popup = CreatePopup(instance, header, main, SizeChangedHandle);
            popup.PopupBackground = popupBackground;
            popup.PresenterBackground = presenterBackground;
            popup.PopupMaxWidth = maxWidth;
            popup.PopupMaxHeight = maxHeight;
            popup.PopupWidth = width;
            popup.PopupHeight = height;
            return popup;
        }
        /// <summary>
        /// 创建弹出层
        /// </summary>
        /// <param name="instance">应用帮助类注入</param>
        /// <param name="header">头部元素</param>
        /// <param name="main">主体元素</param>
        /// <param name="popupBackground">遮罩背景（枚举值）</param>
        /// <param name="presenterBackground">显示区域背景（枚举值）</param>
        /// <param name="maxWidth">显示区域最大宽度</param>
        /// <param name="maxHeight">显示区域最大高度</param>
        /// <param name="width">显示区域宽度，默认为<c>NaN</c></param>
        /// <param name="height">显示区域高度，默认为<c>NaN</c></param>
        /// <param name="SizeChangedHandle">窗口大小变化时的额外处理逻辑</param>
        /// <returns></returns>
        public static CenterPopup CreatePopup(Instance instance, ICenterPopupHeader header, object main, Enum popupBackground, Enum presenterBackground, double maxWidth, double maxHeight, double width = double.NaN, double height = double.NaN, Action<Size> SizeChangedHandle = null)
        {
            var popup = CreatePopup(instance, header, main, SizeChangedHandle);
            popup.PopupBackground = instance.App.GetThemeBrushFromResource(popupBackground);
            popup.PresenterBackground = instance.App.GetThemeBrushFromResource(presenterBackground);
            popup.PopupMaxWidth = maxWidth;
            popup.PopupMaxHeight = maxHeight;
            popup.PopupWidth = width;
            popup.PopupHeight = height;
            return popup;
        }
        /// <summary>
        /// 创建弹出层
        /// </summary>
        /// <param name="instance">应用帮助类注入</param>
        /// <param name="header">头部元素</param>
        /// <param name="main">主体元素</param>
        /// <param name="popupBackground">遮罩背景</param>
        /// <param name="presenterBackground">显示区域背景</param>
        /// <param name="shadowColor">阴影颜色</param>
        /// <param name="shadowOpacity">阴影不透明度</param>
        /// <param name="shadowBlur">阴影模糊度</param>
        /// <param name="maxWidth">显示区域最大宽度</param>
        /// <param name="maxHeight">显示区域最大高度</param>
        /// <param name="width">显示区域宽度，默认为<c>NaN</c></param>
        /// <param name="height">显示区域高度，默认为<c>NaN</c></param>
        /// <param name="SizeChangedHandle">窗口大小变化时的额外处理逻辑</param>
        /// <returns></returns>
        public static CenterPopup CreatePopup(Instance instance, ICenterPopupHeader header, object main, Brush popupBackground, Brush presenterBackground,Color shadowColor,double shadowOpacity,double shadowBlur, double maxWidth, double maxHeight, double width = double.NaN, double height = double.NaN, Action<Size> SizeChangedHandle = null)
        {
            var popup = CreatePopup(instance, header, main, popupBackground, presenterBackground, maxWidth, maxHeight, width, height, SizeChangedHandle);
            popup.ShadowColor = shadowColor;
            popup.ShadowBlur = shadowBlur;
            popup.ShadowOpacity = shadowOpacity;
            return popup;
        }
    }
}
