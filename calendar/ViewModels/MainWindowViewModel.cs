using calendar.Utilities;
using calendar.ViewModels.Commands;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace calendar.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private static ViewModel _view;

        public MainWindowViewModel()
        {
            try
            {
                if (File.Exists(".calfile"))
                {
                    FileManager.LoadFile(File.ReadAllText(".calfile"));
                }
            }
            catch (Exception)
            {
                Trace.WriteLine($"Error loading file '{File.ReadAllText(".calfile")}'");
            }

            // Výchozí ViewModel hlavního okna je měsíční zobrazení kalendáře
            _view = new CalendarMonthViewModel(DateTime.Now);

            FileManager.FileChanged += () => OnStaticPropertyChanged(nameof(FileMessageString));
        }

        public static event PropertyChangedEventHandler StaticPropertyChanged;

        // Vytvoření Commandů pro zobrazení kalendáře podle měsíce/týdne/dne
        public ChangeViewModelCommand<CalendarMonthViewModel> Command_ViewMonth { get; } = new(DateTime.Now);
        public ChangeViewModelCommand<CalendarWeekViewModel> Command_ViewWeek { get; } = new(DateTime.Now);
        public ChangeViewModelCommand<CalendarDayViewModel> Command_ViewDay { get; } = new(DateTime.Now);
        // Vytvoření Commandu pro zobrazení statistik
        public ChangeViewModelCommand<StatsViewModel> Command_ViewStats { get; } = new();
        // Vytvoření Commandů pro načítání z/ukládání do souboru
        public NewFileCommand Command_NewFile { get; } = new();
        public LoadCommand Command_Load { get; } = new();
        public SaveCommand Command_Save { get; } = new();
        public SaveAsCommand Command_SaveAs { get; } = new();

        // Aktuální ViewModel hlavního okna, který lze změnit dle potřeby (např. při změně zobrazení)
        public static ViewModel ViewModel
        {
            get => _view;
            set
            {
                _view = value;
                OnStaticPropertyChanged(nameof(ViewModel));
            }
        }

        public static string FileMessageString
        {
            get
            {
                string fileName = FileManager.CurrentFileName == null ? "<žádný>" : Path.GetFileName(FileManager.CurrentFileName);
                return $"Aktuální soubor: { fileName }{ (FileManager.CurrentFileModified ? "*" : "") }";
            }
        }

        // Podobný princip jako OnPropertyChanged, ale pro statické vlastnosti
        public static void OnStaticPropertyChanged([CallerMemberName] string propertyName = "")
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}
