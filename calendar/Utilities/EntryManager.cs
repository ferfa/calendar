using calendar.Models;
using calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace calendar.Utilities
{
    public static class EntryManager
    {
        public static List<CalendarEntry> Entries { get; } = new();

        public static event Action TasksModified;

        public static void AddEntry(CalendarEntry taskModel)
        {
            Entries.Add(taskModel);
        }

        // TODO: replace OnTasksModified with ObservableCollection
        public static void DeleteEntry(CalendarEntry taskModel)
        {
            Entries.Remove(taskModel);
            OnTasksModified();
        }

        public static List<CalendarEntry> GetEntriesByDate(DateTime date)
        {
            var query = from entry in Entries
                    where (entry is TaskModel task && task.DateAndTime.Date == date)
                    || (entry is RepeatingTaskModel repeatingTask && repeatingTask.RepeatingDayOfWeek == date.DayOfWeek)
                    orderby (entry as TaskModel)?.DateAndTime.TimeOfDay
                    select entry;

            return new List<CalendarEntry>(query);
        }

        public static void OnTasksModified()
        {
            TasksModified?.Invoke();
        }
    }
}
