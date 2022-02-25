using System.Windows.Media;

namespace CircleTimeSelector
{
    public static class PickerIcon
    {
        public static ImageSource Normal { get; }
            = new ImageSourceConverter().ConvertFromString("pack://application:,,,/CircleTimeSelector;component/Images/picker.png") as ImageSource
            ?? throw new System.Exception("picker.png not found");
        public static ImageSource OnHold { get; }
            = new ImageSourceConverter().ConvertFromString("pack://application:,,,/CircleTimeSelector;component/Images/pickerOnhold.png") as ImageSource
            ?? throw new System.Exception("pickerOnhold.png not found");
    }
}
