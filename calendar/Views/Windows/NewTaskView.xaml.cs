using System;
using System.Windows;
using calendar.Utilities;
using calendar.Models;

namespace calendar.Views
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
            TaskManager.AddTask("název", "detaily", DateTime.Now, DateTime.Now.TimeOfDay);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
