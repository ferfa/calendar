using calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace calendar.Utilities
{
    public static class TaskManager
    {
        public static List<TaskViewModel> Tasks { get; } = new();

        public static event Action TasksModified;

        //public static void AddTask(string name, string details, DateTime dateAndTime)
        //{
        //    Tasks.Add(new TaskViewModel()
        //    {
        //        Name = name,
        //        Details = details,
        //        DateAndTime = dateAndTime,
        //    });
        //}

        public static void AddTask(TaskViewModel taskViewModel)
        {
            Tasks.Add(taskViewModel);
            Trace.WriteLine($"Task created: { taskViewModel.Name } ({ taskViewModel.Guid })");
        }

        public static void DeleteTask(TaskViewModel taskViewModel)
        {
            Tasks.Remove(taskViewModel);
            Trace.WriteLine($"Task deleted: { taskViewModel.Name } ({ taskViewModel.Guid })");
            OnTasksModified();
        }

        public static List<TaskViewModel> GetTasksByDate(DateTime date)
        {
            var query = from task in Tasks
                        where task.DateAndTime.Date == date.Date
                        orderby task.DateAndTime.TimeOfDay
                        select task;

            return new List<TaskViewModel>(query);
        }

        public static void OnTasksModified()
        {
            TasksModified?.Invoke();
        }
    }
}
