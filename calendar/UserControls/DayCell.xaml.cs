using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace calendar.UserControls
{
    /// <summary>
    /// Interaction logic for DayCell.xaml
    /// </summary>
    
    // TODO: add a (custom) date selector
    public partial class DayCell : UserControl
    {
        public Day DayInThisCell { get; set; }

        // Used to be displayed on the cell
        public int? DayNumber
        {
            get
            {
                return DayInThisCell?.Date.Day ?? null;
            }
        }

        public DayCell()
        {
            DayManager.DayCells.Add(this);
            Visibility = Visibility.Hidden; // Cells occupied by actual Days will be made visible by DayManager

            TaskManager.UpdateDayCells += TaskManager_UpdateDayCell;

            InitializeComponent();
            DataContext = this;
        }

        public void Disable()
        {
            Visibility = Visibility.Hidden;
            DayInThisCell = null;
        }

        // Binds
        public void Rebind()
        {
            DayNumberTB.Text = DayNumber.ToString();
            TasksLB.ItemsSource = DayInThisCell?.Tasks;
        }

        // Updates the Tasks ListBox
        private void TaskManager_UpdateDayCell()
        {
            if (DayInThisCell?.Tasks != null)
            {
                TasksLB.ItemsSource = new ObservableCollection<Task>(DayInThisCell.Tasks);
            }   
        }

        // Occurs when a Task item is double clicked on
        private void TasksLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TasksLB.SelectedItem != null)
            {
                new Windows.TaskDetailsWindow((Task)TasksLB.SelectedItem).Show();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            new Windows.TaskDetailsWindow((Task)element.DataContext).Show();
        }

        // Popup mouse enter/leave delay
        private void SelectedSP_MouseEnter(object sender, MouseEventArgs e)
        {
            FrameworkElement el = sender as FrameworkElement;
            Popup popup = (Popup)el.FindName("OverviewPopup");

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.2) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();

                if (el.IsMouseOver)
                {
                    popup.IsOpen = true;
                }
            };
        }

        private void SelectedSP_MouseLeave(object sender, MouseEventArgs e)
        {
            FrameworkElement el = sender as FrameworkElement;
            Popup popup = (Popup)el.FindName("OverviewPopup");

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.5) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();

                if (!el.IsMouseOver)
                {
                    popup.IsOpen = false;
                }
            };
        }
    }
}
