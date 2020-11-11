using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using calendar.Models;
using calendar.ViewModels;

namespace calendar.Utilities
{
    public static class TaskManager
    {
        public static event Action TasksModified;

        public static List<TaskViewModel> Tasks { get; } = new List<TaskViewModel>();

        public static void AddTask(string name, string details, DateTime dateAndTime)
        {
            Tasks.Add(new TaskViewModel()
            {
                Name = name,
                Details = details,
                DateAndTime = dateAndTime,
            });
        }

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
                        select task;

            return new List<TaskViewModel>(query);
        }

        public static void OnTasksModified()
        {
            TasksModified?.Invoke();
        }
    }
}
