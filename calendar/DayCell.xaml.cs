using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new NewTaskWindow(DayNumber).Show();
        }
    }
}
