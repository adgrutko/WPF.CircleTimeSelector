using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace CircleTimeSelector
{
    public class HexToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string hexColor = value is string ? (string)value : "#FFF";
            return (new BrushConverter().ConvertFromString(hexColor)) as Brush ?? Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var m = value is Core.Margin ? (Core.Margin)value : new Core.Margin(0);
            return new Thickness(m.Left, m.Top, m.Right, m.Bottom);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var m = value is Core.Point ? (Core.Point)value : new Core.Point(0,0);
            return new Point(m.X, m.Y);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var m = value is Core.Size ? (Core.Size)value : new Core.Size(0,0);
            return new Size(m.Width, m.Height);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    public class PickerIconToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var icon = value is Core.PickerIconEnum ? (Core.PickerIconEnum)value : Core.PickerIconEnum.Normal;
            if (icon == Core.PickerIconEnum.OnHold)
                return PickerIcon.OnHold;
            else
                return PickerIcon.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

}
