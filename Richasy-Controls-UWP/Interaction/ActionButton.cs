using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Richasy.Controls.UWP.Interaction
{
    public class ActionButton:ExtraButton
    {
        public ActionButton()
        {
            this.DefaultStyleKey = typeof(ActionButton);
        }

        public IconElement Icon
        {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconElement), typeof(ActionButton), new PropertyMetadata(null));

        public double Diameter
        {
            get { return (double)GetValue(DiameterProperty); }
            set { SetValue(DiameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Diameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiameterProperty =
            DependencyProperty.Register("Diameter", typeof(double), typeof(ActionButton), new PropertyMetadata(double.NaN,new PropertyChangedCallback(Diameter_Changed)));

        private static void Diameter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue!=null && e.NewValue is double meter)
            {
                var instance = d as ActionButton;
                instance.Width = instance.Height = meter;
                instance.CornerRadius = new CornerRadius(meter / 2.0);
            }
        }

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(ActionButton), new PropertyMetadata(false,new PropertyChangedCallback(IsLoading_Changed)));

        private static void IsLoading_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue is bool isLoading)
            {
                var instance = d as ActionButton;
                instance.IsEnabled = !isLoading;
                if (isLoading)
                {
                    VisualStateManager.GoToState(instance, "Loading", true);
                }
                else
                {
                    VisualStateManager.GoToState(instance, "Default", true);
                }
            }
        }
    }
}
