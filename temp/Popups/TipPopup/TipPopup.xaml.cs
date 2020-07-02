using Richasy.Helper.UWP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class TipPopup : UserControl
    {
        private Instance _instance;
        private Popup _popup = null;
        private Guid _guid;
        public TipPopup()
        {
            this.InitializeComponent();
            _guid = Guid.NewGuid();
            this.Width = Window.Current.Bounds.Width;
            this.Height = Window.Current.Bounds.Height;
            _popup = new Popup();
            _popup.Child = this;
        }

        public TipPopup(Instance instance):this()
        {
            _instance = instance;
        }

        public TipPopup(Instance instance, object content) : this(instance)
        {
            PopupContent = content;
        }

        public Brush PopupBackground
        {
            get { return (Brush)GetValue(PopupBackgroundProperty); }
            set { SetValue(PopupBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupBackgroundProperty =
            DependencyProperty.Register("PopupBackground", typeof(Brush), typeof(TipPopup), new PropertyMetadata(null));

        public Brush PopupForeground
        {
            get { return (Brush)GetValue(PopupForegroundProperty); }
            set { SetValue(PopupForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupForegroundProperty =
            DependencyProperty.Register("PopupForeground", typeof(Brush), typeof(TipPopup), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public object PopupContent
        {
            get { return (object)GetValue(PopupContentProperty); }
            set { SetValue(PopupContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupContentProperty =
            DependencyProperty.Register("PopupContent", typeof(object), typeof(TipPopup), new PropertyMetadata(null));

        public Thickness PopupPadding
        {
            get { return (Thickness)GetValue(PopupPaddingProperty); }
            set { SetValue(PopupPaddingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupPadding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupPaddingProperty =
            DependencyProperty.Register("PopupPadding", typeof(Thickness), typeof(TipPopup), new PropertyMetadata(new Thickness(10)));

        public CornerRadius PopupCornerRadius
        {
            get { return (CornerRadius)GetValue(PopupCornerRadiusProperty); }
            set { SetValue(PopupCornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupCornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupCornerRadiusProperty =
            DependencyProperty.Register("PopupCornerRadius", typeof(CornerRadius), typeof(TipPopup), new PropertyMetadata(new CornerRadius(3)));

        public double PopupMaxWidth
        {
            get { return (double)GetValue(PopupMaxWidthProperty); }
            set { SetValue(PopupMaxWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupMaxWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupMaxWidthProperty =
            DependencyProperty.Register("PopupMaxWidth", typeof(double), typeof(TipPopup), new PropertyMetadata(300.0));



        public async void Show(Enum colorType, double staySeconds=1.5)
        {
            _instance.AddWindowSizeChangeAction(_guid, (size) =>
            {
                Width = size.Width;
                Height = size.Height;
            });
            PopupBackground = _instance.App.GetThemeBrushFromResource(colorType);
            _popup.IsOpen = true;
            PopupContainer.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(staySeconds));
            PopupContainer.Visibility = Visibility.Collapsed;
            _popup.IsOpen = false;
            _instance.RemoveWindowSizeChangeAction(_guid);
        }
    }
}
