using System;
using System.Windows;
using calendar.Utilities;

namespace calendar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal App()
        {
            DayManager.Init(DateTime.Now.Year, DateTime.Now.Month);
        }
    }
}
