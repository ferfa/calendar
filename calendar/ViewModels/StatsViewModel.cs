using calendar.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.ViewModels
{
    public class StatsViewModel : ViewModel
    {
        public StatsViewModel()
        {
            // Statistiky se zobrazují pouze pro úkoly, jež se v kalendáři vyskytují vícekrát
            var query = from repeatingEntry in EntryManager.Entries
                        where repeatingEntry.Count > 1
                        select repeatingEntry;

            // Přiřazení progress barů k tomuto ViewModelu
            foreach (var entry in query)
            {
                StatBars.Add(new StatBarViewModel(entry));
            }
        }

        public override string Title => "Statistiky";

        public List<StatBarViewModel> StatBars { get; set; } = new();
    }
}
