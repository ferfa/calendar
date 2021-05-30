using calendar.Models;
using calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace calendar.Utilities
{
    public static class FileManager
    {
        private static string _currentFileName;
        private static bool _currentFileModified;

        public static string CurrentFileName
        {
            get => _currentFileName;
            set
            {
                _currentFileName = value;
                OnFileChanged();
            }
        }

        public static bool CurrentFileModified
        {
            get => _currentFileModified;
            set
            {
                _currentFileModified = value;
                OnFileChanged();
            }
        }

        public static void NewFile()
        {

        }

        public static void LoadFile(string fileName)
        {
            using StreamReader r = new(fileName);
            string json = r.ReadToEnd();
            EntryManager.Entries = JsonSerializer.Deserialize<List<EntryModel>>(json);
            foreach (EntryModel entry in EntryManager.Entries)
            {
                entry.AfterLoad();
            }
            EntryManager.OnTasksModified();
            CurrentFileName = fileName;
            CurrentFileModified = false;
            UpdateLastFile();
        }

        public static void SaveFile(string fileName)
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(EntryManager.Entries));
            CurrentFileName = fileName;
            CurrentFileModified = false;
            UpdateLastFile();
        }

        private static void UpdateLastFile()
        {
            if (File.Exists(".calfile"))
            {
                File.SetAttributes(".calfile", FileAttributes.Normal);
            }
            File.WriteAllText(".calfile", CurrentFileName);
            File.SetAttributes(".calfile", FileAttributes.Hidden);
        }

        public static event Action FileChanged;

        public static void OnFileChanged()
        {
            FileChanged?.Invoke();
        }
    }
}
