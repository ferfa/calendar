using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace calendar
{
    public class Task : INotifyPropertyChanged
    {
        public Guid GetGuid { get; } = Guid.NewGuid();

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

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value; OnPropertyChanged();
            }
        }

        private DateTime _time;
        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value; OnPropertyChanged();
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
