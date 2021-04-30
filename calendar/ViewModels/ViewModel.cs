namespace calendar.ViewModels
{
    public abstract class ViewModel : ObservableObject
    {
        // Tento řetězec lze upravit dle potřeb ve ViewModelech
        public virtual string Title { get; } = "Kalendář";
    }
}
