using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Richasy.Controls.UWP.Interaction
{
    public class ExtraTextBox : TextBox
    {
        public ExtraTextBox()
        {
            this.DefaultStyleKey = typeof(ExtraTextBox);
        }
        public Brush PointerOverBackground
        {
            get { return (Brush)GetValue(PointerOverBackgroundProperty); }
            set { SetValue(PointerOverBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PointerOverBackgroundProperty =
            DependencyProperty.Register("PointerOverBackground", typeof(Brush), typeof(ExtraTextBox), new PropertyMetadata(null));

        public Brush PointerOverForeground
        {
            get { return (Brush)GetValue(PointerOverForegroundProperty); }
            set { SetValue(PointerOverForegroundProperty, value); }
        }

        public static readonly DependencyProperty PointerOverForegroundProperty =
            DependencyProperty.Register("PointerOverForeground", typeof(Brush), typeof(ExtraTextBox), new PropertyMetadata(null));

        public Brush PointerOverBorderBrush
        {
            get { return (Brush)GetValue(PointerOverBorderBrushProperty); }
            set { SetValue(PointerOverBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty PointerOverBorderBrushProperty =
            DependencyProperty.Register("PointerOverBorderBrush", typeof(Brush), typeof(ExtraTextBox), new PropertyMetadata(null));

        public Brush DisabledBackground
        {
            get { return (Brush)GetValue(DisabledBackgroundProperty); }
            set { SetValue(DisabledBackgroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledBackgroundProperty =
            DependencyProperty.Register("DisabledBackground", typeof(Brush), typeof(ExtraTextBox), new PropertyMetadata(null));

        public Brush DisabledForeground
        {
            get { return (Brush)GetValue(DisabledForegroundProperty); }
            set { SetValue(DisabledForegroundProperty, value); }
        }

        public static readonly DependencyProperty DisabledForegroundProperty =
            DependencyProperty.Register("DisabledForeground", typeof(Brush), typeof(ExtraTextBox), new PropertyMetadata(null));

        public Brush DisabledBorderBrush
        {
            get { return (Brush)GetValue(DisabledBorderBrushProperty); }
            set { SetValue(DisabledBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty DisabledBorderBrushProperty =
            DependencyProperty.Register("DisabledBorderBrush", typeof(Brush), typeof(ExtraTextBox), new PropertyMetadata(null));

        public Brush FocusBackground
        {
            get { return (Brush)GetValue(FocusBackgroundProperty); }
            set { SetValue(FocusBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FocusBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FocusBackgroundProperty =
            DependencyProperty.Register("FocusBackground", typeof(Brush), typeof(ExtraTextBox), new PropertyMetadata(null));

        public Brush FocusForeground
        {
            get { return (Brush)GetValue(FocusForegroundProperty); }
            set { SetValue(FocusForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FocusForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FocusForegroundProperty =
            DependencyProperty.Register("FocusForeground", typeof(Brush), typeof(ExtraTextBox), new PropertyMetadata(null));

        public Brush FocusBorderBrush
        {
            get { return (Brush)GetValue(FocusBorderBrushProperty); }
            set { SetValue(FocusBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FocusBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FocusBorderBrushProperty =
            DependencyProperty.Register("FocusBorderBrush", typeof(Brush), typeof(ExtraTextBox), new PropertyMetadata(null));

        public ElementTheme FocusTheme
        {
            get { return (ElementTheme)GetValue(FocusThemeProperty); }
            set { SetValue(FocusThemeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FocusRequestTheme.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FocusThemeProperty =
            DependencyProperty.Register("FocusTheme", typeof(ElementTheme), typeof(ExtraTextBox), new PropertyMetadata(ElementTheme.Light));


        /// <summary>
        /// 类型是ActionButton
        /// </summary>
        public Style DeleteButtonStyle
        {
            get { return (Style)GetValue(DeleteButtonStyleProperty); }
            set { SetValue(DeleteButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteButtonStyleProperty =
            DependencyProperty.Register("DeleteButtonStyle", typeof(Style), typeof(ExtraTextBox), new PropertyMetadata(null));


    }
}
