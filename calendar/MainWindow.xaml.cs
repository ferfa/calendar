using System;
using System.Windows;

namespace calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            DayManager.Init(DateTime.Now.Year, DateTime.Now.Month); // Pass the current month to DayManager
        }

        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            new NewTaskWindow().Show();
        }
    }
}