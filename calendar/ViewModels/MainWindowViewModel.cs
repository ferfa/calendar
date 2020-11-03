﻿using calendar.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace calendar.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private static ViewModel _view;

        public MainWindowViewModel()
        {
            _view = new CalendarMonthViewModel();
        }

        public static event PropertyChangedEventHandler StaticPropertyChanged;

        public static ViewModel ViewModel
        {
            get => _view;
            set
            {
                _view = value;
                OnStaticPropertyChanged();
            }
        }

        // TODO: move StaticPropertyChanged to ObservableObject
        protected static void OnStaticPropertyChanged([CallerMemberName] string propertyName = "")
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}