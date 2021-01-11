using calendar.Models;
using calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace calendar.Utilities
{
    public static class TaskManager
    {
        public static List<TaskModel> Tasks { get; } = new();

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

        public static void AddTask(TaskModel taskModel)
        {
            Tasks.Add(taskModel);
            Trace.WriteLine($"Task created: { taskModel.Name } ({ taskModel.Guid })");
        }

        public static void DeleteTask(TaskModel taskModel)
        {
            Tasks.Remove(taskModel);
            Trace.WriteLine($"Task deleted: { taskModel.Name } ({ taskModel.Guid })");
            OnTasksModified();
        }

        public static List<TaskModel> GetTasksByDate(DateTime date)
        {
            var query = from task in Tasks
                        where task.DateAndTime.Date == date.Date
                        orderby task.DateAndTime.TimeOfDay
                        select task;

            return new List<TaskModel>(query);
        }

        public static void OnTasksModified()
        {
            TasksModified?.Invoke();
        }
    }
}
