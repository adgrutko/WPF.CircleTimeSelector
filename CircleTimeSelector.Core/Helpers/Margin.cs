namespace CircleTimeSelector.Core
{
    public struct Margin
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }

        public Margin(double v) : this(v, v, v, v) { }
        public Margin(double x, double y) : this(x, y, x, y) { }
        public Margin(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}
