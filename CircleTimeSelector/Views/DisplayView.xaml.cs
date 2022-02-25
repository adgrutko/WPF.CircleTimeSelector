using CircleTimeSelector.Core.ViewModels;
using System.Windows.Controls;

namespace CircleTimeSelector
{
    public partial class DisplayView : UserControl
    {
        public DisplayView()
        {
            InitializeComponent();
            DataContext = new DisplayViewModel();
        }
    }
}
