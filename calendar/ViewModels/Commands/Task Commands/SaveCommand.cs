using calendar.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace calendar.ViewModels.Commands
{
    public class SaveCommand : ICommand
    {
        public SaveCommand()
        {
            FileManager.FileChanged += () => CanExecuteChanged?.Invoke(null, null);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return FileManager.CurrentFileModified || FileManager.CurrentFileName == null;
        }

        public void Execute(object parameter)
        {
            if (FileManager.CurrentFileName != null)
            {
                FileManager.SaveFile(FileManager.CurrentFileName);
            }
            else
            {
                new SaveAsCommand().Execute(null);
            }
        }
    }
}
