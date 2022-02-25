using CircleTimeSelector.Core;
using CircleTimeSelector.Core.ViewModels;
using System;
using System.Windows.Controls;

namespace CircleTimeSelector
{
    public partial class TimePickerView : UserControl
    {
        public TimePickerView()
        {
            InitializeComponent();
            DataContext = new TimePickerViewModel();
        }

        public void Configure(InitialConfiguration c, TimePickerHandler? onTimeChange)
        {
            var time = DateTime.Now.TimeOfDay;
            var configuration = new TimePickerConfiguration(
                hoursF.DataContext as FaceViewModel,
                minutesF.DataContext as FaceViewModel,
                displayD.DataContext as DisplayViewModel,
                time,
                new FaceConfiguration(
                    c.HoursFaceColorHex, c.HoursFaceBackgroundColorHex,
                    Const.HoursFaceWidth, Const.HoursFaceHeight,
                    Const.HoursInDay, Const.HoursRadius, time.Hours),
                new FaceConfiguration(
                    c.MinutesFaceColorHex, c.MinutesFaceBackgroundColorHex,
                    Const.MinutesFaceWidth, Const.MinutesFaceHeight,
                    Const.MinutesInHour, Const.MinutesRadius, time.Minutes));
            (DataContext as TimePickerViewModel)?.Configure(configuration);
            (DataContext as TimePickerViewModel).OnTimeChange += (TimeSpan t) => onTimeChange?.Invoke(t);
        }
    }
}
