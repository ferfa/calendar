using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace calendar
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        public int DayNumber { get; }

        public AddTaskWindow(Day day)
        {
            DayNumber = day.DayNumber;

            InitializeComponent();
            DataContext = this;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            TaskManager.AddTask(new Task()
            {
                Date = new DateTime(2020, 10, DayNumber),
                Name = NewTaskNameTB.Text,
                Details = NewTaskDetailsTB.Text
            }); 

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
