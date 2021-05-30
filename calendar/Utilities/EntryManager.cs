using calendar.Models;
using calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace calendar.Utilities
{
    // Statická třída sloužící ke správě úkolů
    public static class EntryManager
    {
        // Obsahuje všechny úkoly v kalendáři
        public static List<EntryModel> Entries { get; set; } = new();

        // Tento event je vyvolána pokaždé, kdy by se měl aktualizovat List úkolů
        public static event Action TasksModified;

        // Přidání úkolu
        public static void AddEntry(EntryModel entryModel)
        {
            Entries.Add(entryModel);
            FileManager.CurrentFileModified = true;
        }

        // Smazání jednotlivého výskytu úkolu; pokud již žádný nezbyde, úkol se smaže kompletně
        public static void DeleteEntry(EntryModel entryModel, DateTime date)
        {
            entryModel.Deleted.Add(date);
            entryModel.Completed.Remove(date);
            if (entryModel.Count == 0)
            {
                DeleteAllEntries(entryModel);
            }
            OnTasksModified();
        }

        // Kompletní smazání úkolu
        public static void DeleteAllEntries(EntryModel entryModel)
        {
            Entries.Remove(entryModel);
            OnTasksModified();
        }

        // Vrátí List se všemi úkoly, které se vyskytují v daný den
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
