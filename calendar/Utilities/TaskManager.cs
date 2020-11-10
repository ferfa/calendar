using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using calendar.Models;
using calendar.ViewModels;

namespace calendar.Utilities
{
    public static class TaskManager
    {
        public static event Action TasksModified;

        public static List<TaskModel> Tasks { get; } = new List<TaskModel>();

        public static void AddTask(string name, string details, DateTime dateAndTime)
        {
            Tasks.Add(new TaskModel()
            {
                Name = name,
                Details = details,
                DateAndTime = dateAndTime,
            });
        }

        public static void AddTask(TaskModel taskModel)
        {
            Tasks.Add(taskModel);
        }

        public static void DeleteTask(TaskModel taskModel)
        {
            Tasks.Remove(taskModel);
            OnTasksModified();
        }

        public static List<TaskModel> GetTasksByDate(DateTime date)
        {
            var query = from task in Tasks
                        where task.DateAndTime.Date == date.Date
                        select task;

            return new List<TaskModel>(query);
        }

        public static void OnTasksModified()
        {
            TasksModified?.Invoke();
        }
    }
}
