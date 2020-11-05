using System;
using System.Windows;
using calendar.Utilities;
using calendar.ViewModels;
using calendar.Views;

namespace calendar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            new TaskDetailsViewModel(new Models.TaskModel());
        }
    }
}
