using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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

namespace calendar
{
    /// <summary>
    /// Interaction logic for DayCell.xaml
    /// </summary>
    public partial class DayCell : UserControl
    {
        public static readonly DependencyProperty DayNumberProperty = DependencyProperty.Register("DayNumber", typeof(int), typeof(DayCell));

        public int DayNumber {
            get {
                return (int)GetValue(DayNumberProperty);
            }
            set {
                SetValue(DayNumberProperty, value);
            }
        }

        public ObservableCollection<Task> Tasks
        {
            get
            {
                return MonthGrid.Days[DayNumber].Tasks;
            }
        }

        public DayCell()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            new NewTaskWindow(DayNumber).Show();
        }

        private void TasksLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (TasksLB.SelectedItem != null)
            {
                new TaskDetailsWindow((Task)TasksLB.SelectedItem).Show();
            }
        }

        private void PopupShow(object sender, MouseEventArgs e)
        {
            FrameworkElement el = sender as FrameworkElement;
            Popup popup = (Popup)((Panel)el).Children[1];
            popup.IsOpen = true;
        }

        private void PopupHide(object sender, MouseEventArgs e)
        {
            FrameworkElement el = sender as FrameworkElement;
            Popup popup = (Popup)((Panel)el).Children[1];
            popup.IsOpen = false;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            new TaskDetailsWindow((Task)TasksLB.SelectedItem).Show();
        }
    }
}
