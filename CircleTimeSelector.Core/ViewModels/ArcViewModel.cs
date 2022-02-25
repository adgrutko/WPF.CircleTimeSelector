namespace CircleTimeSelector.Core.ViewModels
{
    public class ArcViewModel : BaseViewModel
    {
        private string? _strokeColorHex;
        public string? StrokeColorHex
        {
            get => _strokeColorHex;
            set
            {
                _strokeColorHex = value;
                OnPropertyChanged(nameof(StrokeColorHex));
            }
        }

        private string? _backgroundColorHex;
        public string? BackgroundColorHex
        {
            get => _backgroundColorHex;
            set
            {
                _backgroundColorHex = value;
                OnPropertyChanged(nameof(BackgroundColorHex));
            }
        }

        private double _width;
        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private double _arcWidth;
        public double ArcWidth
        {
            get => _arcWidth;
            set
            {
                _arcWidth = value;
                OnPropertyChanged(nameof(ArcWidth));
            }
        }

        private double _arcHeight;
        public double ArcHeight
        {
            get => _arcHeight;
            set
            {
                _arcHeight = value;
                OnPropertyChanged(nameof(ArcHeight));
            }
        }

        private Margin _arcMargin;
        public Margin ArcMargin
        {
            get => _arcMargin;
            set
            {
                _arcMargin = value;
                OnPropertyChanged(nameof(ArcMargin));
            }
        }

        public double Radius { get; set; }
        public int NumberOfUnits { get; set; }

        private Point _arcStartPoint;
        public Point ArcStartPoint 
        {
            get => _arcStartPoint;
            set
            {
                _arcStartPoint = value;
                OnPropertyChanged(nameof(ArcStartPoint));
            }
        }

        private Size _arcSize;
        public Size ArcSize 
        {
            get => _arcSize;
            set
            {
                _arcSize = value;
                OnPropertyChanged(nameof(ArcSize));
            }
        }

        private int _currentValue;
        public int CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                Angle = Calculations.ComputeAngle(_currentValue, NumberOfUnits);
            }
        }

        private double _angle;
        public double Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                ArcEndPoint = Calculations.ComputeCartesianCoordinate(_angle, Radius);
                ArcLarge = Angle > 180.0;
            }
        }

        private Point _arcEndPoint;
        public Point ArcEndPoint
        {
            get => _arcEndPoint;
            set
            {
                _arcEndPoint = value;
                OnPropertyChanged(nameof(ArcEndPoint));
            }
        }

        private bool _arcLarge;
        public bool ArcLarge
        {
            get => _arcLarge;
            set
            {
                _arcLarge = value;
                OnPropertyChanged(nameof(ArcLarge));
            }
        }

        public delegate void ArcClickedHandler();
        public event ArcClickedHandler? ArcClicked;

        public void ArcClick()
        {
            ArcClicked?.Invoke();
        }

        public ArcViewModel()
        {
            Commands.Add("ArcClickCommand", new RelayCommand(
                (object? argument) => ArcClick(),
                (object? argument) => true));
        }

        public void Configure(FaceConfiguration c)
        {
            StrokeColorHex = c.Color;
            BackgroundColorHex = c.BackgroundColor;
            Width = c.Width;
            Height = c.Height;
            Radius = c.Radius;
            NumberOfUnits = c.NumberOfUnits;

            ArcWidth = Radius * 2 + Const.StrokeThickness;
            ArcHeight = Radius * 2 + Const.StrokeThickness;
            ArcMargin = new Margin(Const.StrokeThickness, Const.StrokeThickness, 0, 0);
            ArcStartPoint = new Point(Radius, 0);
            ArcSize = new Size(Radius, Radius);
        }
    }
}
