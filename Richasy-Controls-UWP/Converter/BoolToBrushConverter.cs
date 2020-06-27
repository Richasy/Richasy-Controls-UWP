using Microsoft.Toolkit.Uwp.UI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Richasy.Controls.UWP.Converter
{
    public class BoolToBrushConverter : DependencyObject, IValueConverter
    {
        public Brush TrueBrush
        {
            get { return (Brush)GetValue(TrueBrushProperty); }
            set { SetValue(TrueBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TrueBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TrueBrushProperty =
            DependencyProperty.Register("TrueBrush", typeof(Brush), typeof(BoolToBrushConverter), new PropertyMetadata(null));

        public Brush FalseBrush
        {
            get { return (Brush)GetValue(FalseBrushProperty); }
            set { SetValue(FalseBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FalseBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FalseBrushProperty =
            DependencyProperty.Register("FalseBrush", typeof(Brush), typeof(BoolToBrushConverter), new PropertyMetadata(null));

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool boolValue = value is bool && (bool)value;

            if (ConverterTools.TryParseBool(parameter))
            {
                boolValue = !boolValue;
            }

            return ConverterTools.Convert(boolValue ? TrueBrush : FalseBrush, targetType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool result = Equals(value, ConverterTools.Convert(TrueBrush, value.GetType()));

            if (ConverterTools.TryParseBool(parameter))
            {
                result = !result;
            }

            return result;
        }
    }
}
