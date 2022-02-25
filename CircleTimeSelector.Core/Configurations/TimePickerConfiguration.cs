﻿using CircleTimeSelector.Core.ViewModels;
using System;

namespace CircleTimeSelector.Core
{
    public class TimePickerConfiguration
    {
        public FaceViewModel HoursFaceViewModel { get; set; }
        public FaceViewModel MinutesFaceViewModel { get; set; }
        public DisplayViewModel FaceDisplayViewModel { get; set; }
        public TimeSpan InitialTime { get; set; }
        public FaceConfiguration Hours { get; set; }
        public FaceConfiguration Minutes { get; set; }

        public TimePickerConfiguration(FaceViewModel hoursFaceViewModel, FaceViewModel minutesFaceViewModel, 
            DisplayViewModel displayViewModel, TimeSpan initialTime, FaceConfiguration hours, FaceConfiguration minutes)
        {
            HoursFaceViewModel = hoursFaceViewModel;
            MinutesFaceViewModel = minutesFaceViewModel;
            FaceDisplayViewModel = displayViewModel;
            InitialTime = initialTime;
            Hours = hours;
            Minutes = minutes;
        }
    }
}
