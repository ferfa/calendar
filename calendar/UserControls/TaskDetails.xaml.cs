using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace calendar.UserControls
{
    /// <summary>
    /// Interaction logic for TaskDetails.xaml
    /// </summary>
    public partial class TaskDetails : UserControl
    {
        public DateTime SelectedDate { get; set; }
        public string DisplaySelectedDate
        {
            get
            {
                return SelectedDate.ToShortDateString();
            }
        }

        public TaskDetails()
        {
            SelectedDate = DateTime.Now;

            InitializeComponent();
            DataContext = this;
        }

        private void TaskDateTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TaskDateCalPopup.IsOpen = true;
        }

        private void TaskDateCal_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDate = (DateTime)TaskDateCal.SelectedDate;
            TaskDateCalPopup.IsOpen = false;
            TaskDateTB.Text = DisplaySelectedDate;
        }
    }
}
