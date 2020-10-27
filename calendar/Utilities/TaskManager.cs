﻿using System;
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
        public static List<TaskModel> Tasks { get; } = new List<TaskModel>();

        public static void AddTask(string name, string details, DateTime date, TimeSpan time)
        {
            Tasks.Add(new TaskModel()
            {
                Name = name,
                Details = details,
                Date = date,
                Time = time
            });
        }

        public static List<TaskModel> GetTasksByDate(DateTime date)
        {
            var query = from task in Tasks
                        where task.Date == date.Date
                        select task;

            return new List<TaskModel>(query);
        }


    }
}