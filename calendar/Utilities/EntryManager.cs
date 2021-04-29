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
        public static List<EntryModel> Entries { get; } = new();

        public static event Action TasksModified;

        public static void AddEntry(EntryModel entryModel)
        {
            Entries.Add(entryModel);
        }

        // TODO: replace OnTasksModified with ObservableCollection
        public static void DeleteEntry(EntryModel entryModel, DateTime date)
        {
            entryModel.Deleted.Add(date);
            entryModel.Completed.Remove(date);
            OnTasksModified();
        }

        public static void DeleteAllEntries(EntryModel entryModel)
        {
            Entries.Remove(entryModel);
            OnTasksModified();
        }

        public static List<EntryModel> GetEntriesByDate(DateTime date)
        {
            var query = from entry in Entries
                        where (entry.CheckDay(date) == true)
                        orderby entry.DateAndTime
                        select entry;

            return new List<EntryModel>(query);
        }

        public static void OnTasksModified()
        {
            TasksModified?.Invoke();
        }
    }
}
