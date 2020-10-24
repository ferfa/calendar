using System;
using System.Windows;

namespace calendar.Windows
{
    // TODO: make New Task & Task Details windows more similar
    /// <summary>
    /// Interaction logic for TaskDetailsWindow.xaml
    /// </summary>
    public partial class TaskDetailsWindow : Window
    {
        public Task EditingTask { get; }

        public TaskDetailsWindow(Task task)
        {
            EditingTask = task;

            InitializeComponent();
            DataContext = this;

            TaskDetailsUC.SelectedDate = task.Date;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            TaskManager.ModifyTask(EditingTask, TaskDetailsUC.TaskNameTB.Text, TaskDetailsUC.TaskDetailsTB.Text, (DateTime)TaskDetailsUC.TaskDateCal.SelectedDate);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
