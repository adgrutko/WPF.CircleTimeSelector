namespace CircleTimeSelector.Core
{
    public class InitialConfiguration
    {
        public string DisplayTitle { get; set; }
        public string MinutesFaceColorHex { get; set; }
        public string HoursFaceColorHex { get; set; }
        public string MinutesFaceBackgroundColorHex { get; set; }
        public string HoursFaceBackgroundColorHex { get; set; }

        public InitialConfiguration(string displayTitle, string minutesFaceColorHex, string hoursFaceColorHex, 
            string minutesFaceBackgroundColorHex, string hoursFaceBackgroundColorHex)
        {
            DisplayTitle = displayTitle;
            MinutesFaceColorHex = minutesFaceColorHex;
            HoursFaceColorHex = hoursFaceColorHex;
            MinutesFaceBackgroundColorHex = minutesFaceBackgroundColorHex;
            HoursFaceBackgroundColorHex = hoursFaceBackgroundColorHex;
        }
    }
}
