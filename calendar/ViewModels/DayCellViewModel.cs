using calendar.Models;
using System;
using System.Windows;

namespace calendar.ViewModels
{
    public class DayCellViewModel : ViewModel
    {
        public DayCellViewModel(DateTime date)
        {
            Day = new(date);
        }

        public DayModel Day { get; }

        public Visibility Visibility { get; set; } = Visibility.Visible;
    }
}
