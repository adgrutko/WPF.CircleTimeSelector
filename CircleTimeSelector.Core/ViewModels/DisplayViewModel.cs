namespace CircleTimeSelector.Core.ViewModels
{
    public class DisplayViewModel : BaseViewModel
    {
        private string _titleString = string.Empty;
        public string TitleString
        {
            get { return _titleString; }
            set
            {
                _titleString = value;
                OnPropertyChanged(nameof(TitleString));
            }
        }

        private string _timeString = string.Empty;
        public string TimeString
        {
            get { return _timeString; }
            set
            {
                _timeString = value;
                OnPropertyChanged(nameof(TimeString));
            }
        }

        private TimeSpan _time = DateTime.Now.TimeOfDay;
        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value;
                TimeString = _time.ToString(@"hh\:mm");
            }
        }

        public DisplayViewModel()
        {
        }

        public void Configure(string title, TimeSpan time)
        {
            TitleString = title;
            Time = time;
        }
    }
}
