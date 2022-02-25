using System.Windows.Media;

namespace CircleTimeSelector
{
    internal static class Extensions
    {
        public static string ToHex(this SolidColorBrush brush)
            => brush.Color.ToString();
    }
}
