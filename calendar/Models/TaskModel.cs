using System;
using System.Data;
using System.Diagnostics;

namespace calendar.Models
{
    public class TaskModel
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime DateAndTime { get; set; }

        private Guid _guid;
        public Guid Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                if (_guid == Guid.Empty)
                {
                    _guid = value;
                    return;
                }
                else
                {
                    throw new ReadOnlyException("Task GUID can only be set once (at initialization)");
                }
            }
        }

        public TaskModel()
        {
            Guid = Guid.NewGuid();
            Trace.WriteLine($"{ Name } created");
        }

    }
}
