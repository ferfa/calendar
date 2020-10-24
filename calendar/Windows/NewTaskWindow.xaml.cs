using System;
using System.Windows;

namespace calendar.Windows
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
                TaskDetailsUC.TaskNameTB.Text,
                TaskDetailsUC.TaskDetailsTB.Text,
                TaskDetailsUC.SelectedDate
            );

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
