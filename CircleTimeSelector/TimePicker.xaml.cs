using CircleTimeSelector.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CircleTimeSelector
{
    public partial class TimePicker : UserControl
    {
        #region custom dependency properties

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TimePicker), new PropertyMetadata("FROM"));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty MinutesFaceColorProperty = DependencyProperty.Register("MinutesFaceColor", typeof(SolidColorBrush), typeof(TimePicker), new PropertyMetadata(Brushes.LightSkyBlue));
        public SolidColorBrush MinutesFaceColor
        {
            get { return (SolidColorBrush)GetValue(MinutesFaceColorProperty); }
            set { SetValue(MinutesFaceColorProperty, value); }
        }

        public static readonly DependencyProperty HoursFaceColorProperty = DependencyProperty.Register("HoursFaceColor", typeof(SolidColorBrush), typeof(TimePicker), new PropertyMetadata(Brushes.LightSkyBlue));
        public SolidColorBrush HoursFaceColor
        {
            get { return (SolidColorBrush)GetValue(HoursFaceColorProperty); }
            set { SetValue(HoursFaceColorProperty, value); }
        }

        public static readonly DependencyProperty MinutesFaceBackgroundColorProperty = DependencyProperty.Register("MinutesFaceBackgroundColor", typeof(SolidColorBrush), typeof(TimePicker), new PropertyMetadata(Brushes.LightSkyBlue));
        public SolidColorBrush MinutesFaceBackgroundColor
        {
            get { return (SolidColorBrush)GetValue(MinutesFaceBackgroundColorProperty); }
            set { SetValue(MinutesFaceBackgroundColorProperty, value); }
        }

        public static readonly DependencyProperty HoursFaceBackgroundColorProperty = DependencyProperty.Register("HoursFaceBackgroundColor", typeof(SolidColorBrush), typeof(TimePicker), new PropertyMetadata(Brushes.LightSkyBlue));
        public SolidColorBrush HoursFaceBackgroundColor
        {
            get { return (SolidColorBrush)GetValue(HoursFaceBackgroundColorProperty); }
            set { SetValue(HoursFaceBackgroundColorProperty, value); }
        }

        #endregion

        public event TimePickerHandler OnTimeChange;

        public TimePicker()
        {
            InitializeComponent();
        }

        private void TimePickerLoaded(object sender, RoutedEventArgs e)
        {
            timePickerV.Configure(new InitialConfiguration(Title, 
                MinutesFaceColor.ToHex(),
                HoursFaceColor.ToHex(),
                MinutesFaceBackgroundColor.ToHex(),
                HoursFaceBackgroundColor.ToHex()),
                OnTimeChange);
        }
    }
}
