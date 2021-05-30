using calendar.Utilities;
using calendar.ViewModels;
using calendar.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Data;

namespace calendar.Models
{
    // Model úkolu, obsahuje základní vlastnosti a logiku
    // Je Serializovatelný, tj. lze ho převést např. na JSON a uložit do souboru
    // Vlastnosti, které není potřeba serializovat, jsou označeny [JsonIgnore]
    [Serializable()]
    public class EntryModel : ObservableObject
    {
        private string _name;
        private string _description;
        private DateTime _dateAndTime;
        private DateTime _endDate;
        private Repeat _repeatRule = Repeat.Never;
        private ObservableCollection<DateTime> _completed = new();
        private ObservableCollection<DateTime> _deleted = new();

        public EntryModel()
        {
            // Vytvoření Commandů pro úpravu či mazání úkolu
            Command_Edit = new(this);
            Command_Delete = new(this);

            AfterLoad();

            Trace.WriteLine($"Entry { Name } created.");
        }


        // Přidá anonymní metody k eventům
        // Když se změní kolekce Completed, nebo Deleted, označí se aktuální soubor za neuložený
        public void AfterLoad()
        {
            Completed.CollectionChanged += (_, _) =>
            {
                FileManager.CurrentFileModified = true;
                Trace.WriteLine("Completed changed");
            };

            Deleted.CollectionChanged += (_, _) =>
            {
                FileManager.CurrentFileModified = true;
                Trace.WriteLine("Deleted changed");
            };

            Trace.WriteLine($"Entry { Name } deserialized.");
        }


        // Commandy není potřeba serializovat, uživatel je nijak nemění
        [JsonIgnore]
        public ChangeViewModelCommand<EntryDetailsViewModel> Command_Edit { get; }
        [JsonIgnore]
        public DeleteEntryCommand Command_Delete { get; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                FileManager.CurrentFileModified = true;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                FileManager.CurrentFileModified = true;
                OnPropertyChanged();
            }
        }

        public DateTime DateAndTime
        {
            get => _dateAndTime;
            set
            {
                _dateAndTime = value;
                FileManager.CurrentFileModified = true;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                FileManager.CurrentFileModified = true;
                OnPropertyChanged();
            }
        }

        public Repeat RepeatRule
        {
            get => _repeatRule;
            set
            {
                _repeatRule = value;
                FileManager.CurrentFileModified = true;
                OnPropertyChanged();
            }
        }

        // Enum obsahující všechny možnosti opakování úkolu
        public enum Repeat
        {
            Never,
            Daily,
            Weekly,
            Monthly
        }

        // Kolekce obsahující data, ve kterých je úkol splněn
        public ObservableCollection<DateTime> Completed { get; set; } = new();

        // Kolekce obsahující data, ve kterých je úkol vymazán (v tyto dny se nevykreslí a nezapočítává se do statistik)
        public ObservableCollection<DateTime> Deleted { get; set; } = new();

        // Tato metoda zkontroluje, zda by se měl v daný den úkol vykreslit
        public bool CheckDay(DateTime date)
        {
            // Pokud je v tento den úkol smazán, nevykreslí se
            if (Deleted.Contains(date))
            {
                return false;
            }

            // Pokud se úkol neopakuje a den souhlasí se dnem úkolu, vykreslí se
            if (RepeatRule == Repeat.Never && DateAndTime.Date == date.Date)
            {
                return true;
            }
            // Pokud je den v rozmezí opakujícího se úkolu, zkontroluje, zda se vykreslí podle jednotlivých pravidel
            else if (DateAndTime.Date <= date.Date && EndDate.Date >= date.Date)
            {
                switch (RepeatRule)
                {
                    case Repeat.Daily:
                        return true;
                    case Repeat.Weekly:
                        return (DateAndTime.DayOfWeek == date.DayOfWeek);
                    case Repeat.Monthly:
                        return (DateAndTime.Day == date.Day);
                }
            }

            return false;
        }

        // Tato vlastnost udává, kolikrát se doopravdy v kalendáři úkol vyskytuje
        [JsonIgnore]
        public int Count
        {
            get
            {
                switch (RepeatRule)
                {
                    case Repeat.Never:
                        return 1;
                    case Repeat.Daily:
                        return (EndDate - DateAndTime.Date).Days - Deleted.Count + 1;
                    case Repeat.Weekly:
                        return (EndDate - DateAndTime.Date).Days / 7 - Deleted.Count + 1;
                    case Repeat.Monthly:
                        // Pokud se úkol opakuje měsíčně, je třeba si dát pozor na to, že měsíce nejsou stejně dlouhé
                        int count = 0;
                        DateTime dt = DateAndTime.Date;
                        while (dt <= EndDate)
                        {
                            // Pokud se den (1-31) nevyskytuje v následujícím měsící, přesune se smyčka o dva měsíce
                            if (dt.Month != 12)
                            {
                                if (dt.Day > DateTime.DaysInMonth(dt.Year, dt.Month + 1))
                                {
                                    dt = new DateTime(dt.Year, dt.Month + 2, dt.Day);
                                }
                                else
                                {
                                    dt = new DateTime(dt.Year, dt.Month + 1, dt.Day);
                                }
                            }
                            // Prosinec
                            else
                            {
                                dt = new DateTime(dt.Year + 1, 1, dt.Day);
                            }

                            count++;
                        }

                        return count - Deleted.Count;
                }
                return 0;
            }
        }
    }
}
