using calendar.Utilities;
using calendar.ViewModels.Commands;
using System.ComponentModel;
using System.Windows;

namespace calendar.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (FileManager.CurrentFileModified == true)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Máte neuložené změny. Chcete je uložit?", "Neuložené změny", MessageBoxButton.YesNoCancel);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    if (FileManager.CurrentFileName == null)
                    {
                        new SaveAsCommand().Execute(null);
                    }
                    else
                    {
                        FileManager.SaveFile(FileManager.CurrentFileName);
                    }
                }
                else if (dialogResult == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnClosing(e);
        }
    }
}
