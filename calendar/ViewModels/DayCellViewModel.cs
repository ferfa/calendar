using calendar.Models;
using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
