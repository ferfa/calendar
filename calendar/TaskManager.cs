using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    delegate void Del(Task task);

    class TaskManager
    {
        public static Del UpdateDayCell;

        public static List<Task> Tasks { get; set; } = new List<Task>();

        public static void AddTask(Task task)
        {
            Tasks.Add(task);
            UpdateDayCell(task);
        }
    }
}
