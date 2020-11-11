namespace calendar.ViewModels
{
    public abstract class ViewModel : ObservableObject
    {
        public virtual void Update()
        {
        }

        public virtual string Title { get; } = "Kalendář";
    }
}
