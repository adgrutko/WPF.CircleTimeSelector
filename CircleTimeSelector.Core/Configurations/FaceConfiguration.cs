namespace CircleTimeSelector
{
    public class FaceConfiguration
    {
        public string Color { get; set; }
        public string BackgroundColor { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int NumberOfUnits { get; set; }
        public int Radius { get; set; }
        public int InitialValue { get; set; }

        public FaceConfiguration(string color, string backgroundColor, double width, double height, 
            int numberOfUnits, int radius, int initialValue)
        {
            Color = color;
            BackgroundColor = backgroundColor;
            Width = width;
            Height = height;
            NumberOfUnits = numberOfUnits;
            Radius = radius;
            InitialValue = initialValue;
        }
    }
}
