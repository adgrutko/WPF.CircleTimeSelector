using CircleTimeSelector.Core.ViewModels;
using System.Windows.Controls;

namespace CircleTimeSelector
{
    public partial class ArcView : UserControl
    {
        public ArcView()
        {
            InitializeComponent();
            DataContext = new ArcViewModel();
        }
    }
}
