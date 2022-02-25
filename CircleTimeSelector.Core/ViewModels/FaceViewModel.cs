namespace CircleTimeSelector.Core.ViewModels
{
    public class FaceViewModel : BaseViewModel
    {
        private FaceConfiguration Config { get; set; }

        public void Configure(FaceConfiguration c)
        {
            Config = c;
            Points = Calculations.GetPickerPossiblePositions(Config.NumberOfUnits, Config.Radius);
            ConfigurePicker();
            ConfigureArc();
            SelectedValue = Config.InitialValue;
        }

        private void ConfigurePicker()
        {
            PickerVM.LockSelectionEvent += () => { DuringSelection = true; };
            PickerVM.UnlockSelectionEvent += () => { DuringSelection = false; };
            PickerVM.PickerIcon = PickerIconEnum.Normal;
        }

        public delegate bool HandleExternalMouseMoveHandler();
        public event HandleExternalMouseMoveHandler? ExternalMouseMove;

        private void ConfigureArc()
        {
            ArcVM.ArcClicked += () =>
            {
                PickerVM.TurnPickerOn(!DuringSelection);
                ExternalMouseMove?.Invoke();
            };
            ArcVM.Configure(Config);
        }

        private ArcViewModel ArcVM { get; set; }
        private PickerViewModel PickerVM { get; set; }

        private List<Point> Points { get; set; }
        public bool DuringSelection { get; set; }

        private int _selectedValue;
        public int SelectedValue
        {
            get => _selectedValue;
            set
            {
                _selectedValue = value;
                ArcVM.CurrentValue = value;
                PickerVM.PickerPoint = Points[value];
            }
        }

        public FaceViewModel(ArcViewModel arcViewModel, PickerViewModel pickerViewModel)
        {
            ArcVM = arcViewModel;
            PickerVM = pickerViewModel;
        }

        public void HandleMouseMove(double angleRad)
        {
            if (!DuringSelection) return;
            SelectedValue = Points.NearestIndex(angleRad, Const.CenterX);
        }

        public void FinishSelecting()
        {
            PickerVM.TurnPickerOff();
        }
    }
}
