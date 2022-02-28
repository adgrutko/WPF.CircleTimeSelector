using System;
using System.ComponentModel;
using System.Windows;

namespace CircleTimeSelectorDemo
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private TimeSpan _time;
        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            Time = DateTime.Now.TimeOfDay;
            pickerTP.OnTimeChange += (TimeSpan time) =>
            {
                Time = time;
                if (time == new TimeSpan(12, 0, 0))
                    MessageBox.Show("Midday!");
            };

        }

    }
}
