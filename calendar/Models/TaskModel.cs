using System;
using System.Data;

namespace calendar.Models
{
    public class TaskModel
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        private Guid _guid;
        public Guid Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                if (_guid == null)
                {
                    _guid = value;
                }
                else
                {
                    //throw new ReadOnlyException("Task GUID can only be set once (at initialization)");
                }
            }
        }

        public TaskModel()
        {
            Guid = Guid.NewGuid();
        }

    }
}
