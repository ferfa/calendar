using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace calendar
{
    /// <summary>
    /// Interaction logic for DayCell.xaml
    /// </summary>
    public partial class DayCell : UserControl
    {
        //public static readonly DependencyProperty DayNumberProperty = DependencyProperty.Register("DayNumber", typeof(int), typeof(DayCell));

        //public int DayNumber {
        //    get {
        //        return (int)GetValue(DayNumberProperty);
        //    }
        //    set {
        //        SetValue(DayNumberProperty, value);
        //    }
        //}


        public static readonly DependencyProperty CellIDProperty = DependencyProperty.Register("CellID", typeof(int), typeof(DayCell));

        public int CellID
        {
            get
            {
                return (int)GetValue(CellIDProperty);
            }
            set
            {
                SetValue(CellIDProperty, value);
            }
        }

        public Day DayInThisCell { get; set; }

        public int DayNumber {
            get
            {
                if (DayInThisCell == null)
                {
                    return 0;
                }

                return DayInThisCell.DayNumber;
            }
        }

        public ObservableCollection<Task> Tasks
        {
            get
            {
                if (DayInThisCell == null)
                {
                    return null;
                }

                return DayInThisCell.Tasks;
            }
        }


        public DayCell()
        {
            MonthGrid.DayCells.Add(this);
            Visibility = Visibility.Hidden;

            InitializeComponent();
            DataContext = this;
        }


        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            new NewTaskWindow(DayInThisCell).Show();
        }

        private void TasksLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TasksLB.SelectedItem != null)
            {
                new TaskDetailsWindow((Task)TasksLB.SelectedItem).Show();
            }
        }



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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            new TaskDetailsWindow((Task)element.DataContext).Show();
        }

    }
}
