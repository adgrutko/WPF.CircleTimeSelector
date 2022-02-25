using System.Windows.Input;

namespace CircleTimeSelector.Core.ViewModels
{
    public class BaseViewModel : ObservableProperty
    { 
        public Dictionary<string, ICommand> Commands { get; protected set; }
        public BaseViewModel()
            => Commands = new Dictionary<string, ICommand>();
    }
}
