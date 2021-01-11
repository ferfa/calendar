namespace calendar.ViewModels
{
    public abstract class ViewModel : ObservableObject
    {
        public virtual string Title { get; } = "Kalendář";
    }
}
