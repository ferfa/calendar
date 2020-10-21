using System.Windows;

namespace calendar
{
    // TODO: make New Task & Task Details windows more similar (inheritance?)
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
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            TaskManager.ModifyTask(EditingTask, TaskNameTB.Text, TaskDetailsTB.Text, EditingTask.Date);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
