using System;
using System.Windows;

namespace calendar
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public NewTaskWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            TaskManager.AddTask(
                NewTaskNameTB.Text,
                NewTaskDetailsTB.Text,
                new DateTime(DayManager.Year, DayManager.Month, int.Parse(NewTaskDateTB.Text))
            );

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
