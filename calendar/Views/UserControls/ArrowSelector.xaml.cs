using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace calendar.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ArrowSelector.xaml
    /// </summary>
    public partial class ArrowSelector : UserControl, INotifyPropertyChanged
    {
        private const int _roundMinutes = 15;

        public ArrowSelector()
        {
            InitializeComponent();
        }

        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time",
                typeof(TimeSpan),
                typeof(ArrowSelector),
                new PropertyMetadata(
                    new TimeSpan(0, (int)(Math.Round(DateTime.Now.TimeOfDay.TotalMinutes / _roundMinutes) * _roundMinutes), 0)));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonUp_Click(object sender, RoutedEventArgs e)
        {
            Time = new TimeSpan(0, 0, ((int)Time.TotalMinutes + _roundMinutes) % (24 * 60), 0);

            Trace.WriteLine($"{ Time.Days } d, { Time.Hours } h, { Time.Minutes } m");
        }

        private void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            Time = new TimeSpan(0, 0, ((int)Time.TotalMinutes - _roundMinutes + 24 * 60) % (24 * 60), 0);

            Trace.WriteLine($"{ Time.Days } d, { Time.Hours } h, { Time.Minutes } m");
        }
    }
}
