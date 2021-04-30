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
            // Přiřazení úkolu k progress baru
            _entry = entry;
        }

        public EntryModel Entry => _entry;

        // Kalkulace procentuální úspěšnosti plnění úkolu (bez desetinného místa)
        public double Percentage
        {
            get
            {
                return 100 * _entry.Completed.Count / _entry.Count;
            }
        }
    }
}
