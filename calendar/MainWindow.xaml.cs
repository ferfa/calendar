using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static MonthGrid CurrentMonth { get; } = new MonthGrid();
        
        public MainWindow()
        {

            InitializeComponent();
            DataContext = this;
        }

        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            new NewTaskWindow(6).Show();

            Console.WriteLine(sender);
        }
    }
}