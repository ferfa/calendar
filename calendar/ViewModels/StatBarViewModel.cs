using calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.ViewModels
{
    public class StatBarViewModel : ViewModel
    {
        private EntryModel _entry;

        public StatBarViewModel(EntryModel entry)
        {
            _entry = entry;
        }

        public EntryModel Entry => _entry;

        public double Percentage
        {
            get
            {
                return 100 * _entry.Completed.Count / _entry.Count;
            }
        }
    }
}
