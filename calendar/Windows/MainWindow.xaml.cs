using System;
using System.Windows;
using System.Globalization;
using System.ComponentModel;

namespace calendar.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string DisplayMonthAndYear
        {
            get
            {
                return $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DayManager.Month)} {DayManager.Year}";
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            DayManager.Init(DateTime.Now.Year, DateTime.Now.Month); // Pass the current (default) month to DayManager
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnDayNumberChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged.Invoke(sender, e);
        }

        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            new NewTaskWindow().Show();
        }

        private void PreviousMonthButton_Click(object sender, RoutedEventArgs e)
        {
            if (DayManager.Month == 1)
            {
                DayManager.SetYearAndMonth(DayManager.Year - 1, 12);
            }
            else
            {
                DayManager.SetYearAndMonth(DayManager.Year, DayManager.Month - 1);
            }

            MonthAndYearTB.Text = DisplayMonthAndYear;
        }

        private void NextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            if (DayManager.Month == 12)
            {
                DayManager.SetYearAndMonth(DayManager.Year + 1, 1);
            }
            else
            {
                DayManager.SetYearAndMonth(DayManager.Year, DayManager.Month + 1);
            }

            MonthAndYearTB.Text = DisplayMonthAndYear;
        }
    }
}