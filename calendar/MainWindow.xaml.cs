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
        public static ObservableCollection<string> TaskList { get; } = new ObservableCollection<string>();

        public MainWindow()
        {
            
            
            NewTaskWindow newTaskWindow = new NewTaskWindow();
            newTaskWindow.Show();

            TaskList.Add("úkol");
            TaskList.Add("připomenutí");
            TaskList.Add("schůzka");

            InitializeComponent();
            DataContext = this;
        }

        public static void AddNewTask(string name)
        {
            TaskList.Add(name);
        }
    }
}