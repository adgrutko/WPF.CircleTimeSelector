namespace CircleTimeSelector.Core.ViewModels
{
    public class PickerViewModel : BaseViewModel
    {
        public double Width { get; set; } = Const.PickerWidth;
        public double Height { get; set; } = Const.PickerHeight;

        public Point PickerPoint
        {
            set
            {
                PickerMargin = new Margin(value.X - Width / 2.0, value.Y - Height / 2.0, 0, 0);
                var angleRad = Math.Atan2(Const.CenterX - value.Y, Const.CenterX - value.X);
                PickerAngle = angleRad * 180.0 / Math.PI;
            }
        }

        private Margin _pickerMargin;
        public Margin PickerMargin
        {
            get => _pickerMargin;
            set
            {
                _pickerMargin = value;
                OnPropertyChanged(nameof(PickerMargin));
            }
        }

        private double _pickerAngle;
        public double PickerAngle
        {
            get => _pickerAngle;
            set
            {
                _pickerAngle = value;
                OnPropertyChanged(nameof(PickerAngle));
            }
        }

        private PickerIconEnum _pickerIcon;
        public PickerIconEnum PickerIcon
        {
            get => _pickerIcon;
            set
            {
                _pickerIcon = value;
                OnPropertyChanged(nameof(PickerIcon));
            }
        }

        public delegate void SelectionHandler();
        public event SelectionHandler? LockSelectionEvent;
        public event SelectionHandler? UnlockSelectionEvent;

        public void TurnPickerOn(bool process = true)
        {
            if (!process) return;
            PickerIcon = PickerIconEnum.OnHold;
            LockSelectionEvent?.Invoke();
        }

        public void TurnPickerOff(bool process = true)
        {
            if (!process) return;
            PickerIcon = PickerIconEnum.Normal;
            UnlockSelectionEvent?.Invoke();
        }

        public PickerViewModel()
        {
            Commands.Add("TurnPickerOnCommand", new RelayCommand(
                (object? argument) => TurnPickerOn(true),
                (object? argument) => true));
            Commands.Add("TurnPickerOffCommand", new RelayCommand(
                (object? argument) => TurnPickerOff(),
                (object? argument) => true));
        }
    }
}
