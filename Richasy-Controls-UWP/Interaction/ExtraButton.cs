using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Richasy.Controls.UWP.Interaction
{
    public class ExtraButton:Button
    {
        public ExtraButton()
        {
            this.DefaultStyleKey = typeof(ExtraButton);
        }
        public Brush PointerOverBackground
        {
            get { return (Brush)GetValue(PointerOverBackgroundProperty); }
            set { SetValue(PointerOverBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PointerOverBackgroundProperty =
            DependencyProperty.Register("PointerOverBackground", typeof(Brush), typeof(ExtraButton), new PropertyMetadata(null));

        public Brush PointerOverForeground
        {
            get { return (Brush)GetValue(PointerOverForegroundProperty); }
            set { SetValue(PointerOverForegroundProperty, value); }
        }

        public static readonly DependencyProperty PointerOverForegroundProperty =
            DependencyProperty.Register("PointerOverForeground", typeof(Brush), typeof(ExtraButton), new PropertyMetadata(null));

        public Brush PointerOverBorderBrush
        {
            get { return (Brush)GetValue(PointerOverBorderBrushProperty); }
            set { SetValue(PointerOverBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty PointerOverBorderBrushProperty =
            DependencyProperty.Register("PointerOverBorderBrush", typeof(Brush), typeof(ExtraButton), new PropertyMetadata(null));

        public Brush PressBackground
        {
            get { return (Brush)GetValue(PressBackgroundProperty); }
            set { SetValue(PressBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PressBackgroundProperty =
            DependencyProperty.Register("PressBackground", typeof(Brush), typeof(ExtraButton), new PropertyMetadata(null));

        public Brush PressForeground
        {
            get { return (Brush)GetValue(PressForegroundProperty); }
            set { SetValue(PressForegroundProperty, value); }
        }

        public static readonly DependencyProperty PressForegroundProperty =
            DependencyProperty.Register("PressForeground", typeof(Brush), typeof(ExtraButton), new PropertyMetadata(null));
        public Brush PressBorderBrush
        {
            get { return (Brush)GetValue(PressBorderBrushProperty); }
            set { SetValue(PressBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty PressBorderBrushProperty =
            DependencyProperty.Register("PressBorderBrush", typeof(Brush), typeof(ExtraButton), new PropertyMetadata(null));

        public Brush DisabledBackground
        {
            get { return (Brush)GetValue(DisabledBackgroundProperty); }
            set { SetValue(DisabledBackgroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledBackgroundProperty =
            DependencyProperty.Register("DisabledBackground", typeof(Brush), typeof(ExtraButton), new PropertyMetadata(null));

        public Brush DisabledForeground
        {
            get { return (Brush)GetValue(DisabledForegroundProperty); }
            set { SetValue(DisabledForegroundProperty, value); }
        }

        public static readonly DependencyProperty DisabledForegroundProperty =
            DependencyProperty.Register("DisabledForeground", typeof(Brush), typeof(ExtraButton), new PropertyMetadata(null));

        public Brush DisabledBorderBrush
        {
            get { return (Brush)GetValue(DisabledBorderBrushProperty); }
            set { SetValue(DisabledBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty DisabledBorderBrushProperty =
            DependencyProperty.Register("DisabledBorderBrush", typeof(Brush), typeof(ExtraButton), new PropertyMetadata(null));


    }
}
