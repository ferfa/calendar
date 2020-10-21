using System;
using System.Collections.Generic;

namespace calendar
{
    delegate void UpdateDayCellsHandler();

    static class TaskManager
    {
        public static UpdateDayCellsHandler UpdateDayCells;
        public static List<Task> Tasks { get; set; } = new List<Task>();

        public static void AddTask(string name, string details, DateTime dateAndTime)
        {
            Tasks.Add(new Task(name, details, dateAndTime));
            UpdateDayCells();
        }

        public static void ModifyTask(Task task, string name, string details, DateTime date)
        {
            task.Name = name;
            task.Details = details;
            task.Date = date;
            UpdateDayCells();
        }
    }
}
