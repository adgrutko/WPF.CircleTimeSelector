namespace CircleTimeSelector.Core.ViewModels
{
    public class TimePickerViewModel : BaseViewModel
    {
        public delegate void TimePickerHandler(TimeSpan time);
        public event TimePickerHandler? OnTimeChange;

        private FaceViewModel _hoursVM { get; set; }
        private FaceViewModel _minutesVM { get; set; }
        private DisplayViewModel _displayVM { get; set; }

        private TimeSpan _selectedTime = DateTime.Now.TimeOfDay;
        public TimeSpan SelectedTime
        {
            get { return _selectedTime; }
            set
            {
                _selectedTime = value;
                _hoursVM.SelectedValue = SelectedTime.Hours;
                _minutesVM.SelectedValue = SelectedTime.Minutes;
                OnTimeChange?.Invoke(SelectedTime);
            }
        }

        public TimePickerViewModel()
        {
            Commands.Add("FinishSelecting", new RelayCommand(
                (object? argument) => FinishSelecting(),
                (object? argument) => true));
            Commands.Add("HandleMouseMove", new RelayCommand(
                (object? argument) => HandleMouseMove(),
                (object? argument) => true));
        }

        public void Configure(TimePickerConfiguration c)
        {
            _hoursVM = c.HoursFaceViewModel;
            _hoursVM.Configure(c.Hours);
            _hoursVM.ExternalMouseMove += HandleHoursMouseMove;
            _minutesVM = c.MinutesFaceViewModel;
            _minutesVM.Configure(c.Minutes);
            _minutesVM.ExternalMouseMove += HandleMinutesMouseMove;
            _displayVM = c.FaceDisplayViewModel;
            _displayVM.Configure(c.DisplayTitle, SelectedTime);
            SelectedTime = c.InitialTime;
        }

        private void FinishSelecting()
        {
            _hoursVM.FinishSelecting();
            _minutesVM.FinishSelecting();
        }

        private void HandleMouseMove()
        {
            if (HandleMinutesMouseMove() || HandleHoursMouseMove())
            {
                SelectedTime = new TimeSpan(_hoursVM.SelectedValue, _minutesVM.SelectedValue, 0);
                _displayVM.Time = SelectedTime;
            }
        }

        private double x = 0;
        public double X
        {
            get => x;
            set => x = value;
        }

        private double y = 0;
        public double Y
        {
            get => y;
            set => y = value;
        }
        
        private bool HandleMinutesMouseMove()
        {
            if (!_minutesVM.DuringSelection) 
                return false;
            _minutesVM.HandleMouseMove(Calculations.GetAngleRelativeToCenterRad(X, Y));
            return true;
        }

        private bool HandleHoursMouseMove()
        {
            if (!_hoursVM.DuringSelection) 
                return false;
            _hoursVM.HandleMouseMove(Calculations.GetAngleRelativeToCenterRad(X, Y));
            return true;
        }


    }
}
