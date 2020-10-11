using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace calendar
{
    public class Task : INotifyPropertyChanged
    {

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value; OnPropertyChanged();
            }
        }

        private string details;
        public string Details
        {
            get => details;
            set
            {
                details = value; OnPropertyChanged();
            }
        }

        public Task()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string callerName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
