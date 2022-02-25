namespace CircleTimeSelector.Core
{
    public static class Calculations
    {
        public static Point ComputeCartesianCoordinate(double angle, double radius)
        {
            double angleRad = (Math.PI / 180.0) * (angle - 90.0);

            double x = radius * Math.Cos(angleRad) + radius;
            double y = radius * Math.Sin(angleRad) + radius;

            return new Point(x, y);
        }

        public static Point Nearest(this List<Point> points, double angleRad, double x)
            => points.OrderBy(a => Math.Abs(angleRad - Math.Atan2(x - a.Y, x - a.X))).First();

        public static int NearestIndex(this List<Point> points, double angleRad, double x)
            => points.IndexOf(points.Nearest(angleRad, x));

        public static double GetAngleRelativeToCenterRad(double currentX, double currentY)
            =>  Math.Atan2(Const.CenterX - currentY, Const.CenterX - currentX);

        public static double ComputeAngle(int newValue, int numberOfUnits)
            => ((newValue * 100.0 / numberOfUnits) * 360.0) / 100.0;

        public static List<Point> GetPickerPossiblePositions(int numberOfUnits, double radius)
        {
            // -6 and 18 for 24 hours
            // -15 and 45 for 60 minutes
            // etc
            var minAngleMultiplier = -numberOfUnits / 4;
            var maxAngleMultiplier = numberOfUnits * 3 / 4;

            var positions = new List<Point>();
            var angle = 2 * Math.PI / numberOfUnits;
            for (int i = minAngleMultiplier; i < maxAngleMultiplier; i++)
                positions.Add(new Point(
                    (int)(Const.CenterX + (radius + 50) * Math.Cos(angle * i)),
                    (int)(Const.CenterY + (radius + 50) * Math.Sin(angle * i))));

            return positions;
        }
    }
}
