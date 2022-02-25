using CircleTimeSelector.Core.ViewModels;
using System.Windows.Controls;

namespace CircleTimeSelector
{
    public partial class FaceView : UserControl
    {
        public FaceView()
        {
            InitializeComponent();
            DataContext = new FaceViewModel(
                arcV.DataContext as ArcViewModel, 
                pickerV.DataContext as PickerViewModel);
        }
    }
}
