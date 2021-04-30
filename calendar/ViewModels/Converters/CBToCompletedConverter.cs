using calendar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace calendar.ViewModels.Converters
{
    public class CBToCompletedConverter : IMultiValueConverter
    {
        private object[] _values;

        private EntryModel _entry;
        private DateTime _date;

        // Konvertuje úkol a den na hodnotu isChecked zaškrtávacího políčka
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            _values = (object[])values.Clone();

            _entry = (EntryModel)values[0];
            _date = (DateTime)values[1];

            if (_entry.Completed.Contains(_date))
            {
                return true;
            }

            return false;
        }

        // Konvertuje hodnotu isChecked zaškrtávacího políčka na splnění úkolu v daný den
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if ((bool)value == true && _entry.Completed.Contains(_date) == false)
            {
                _entry.Completed.Add(_date);
            }
            else if ((bool)value == false && _entry.Completed.Contains(_date) == true)
            {
                _entry.Completed.Remove(_date);
            }

            // Vstupní hodnoty se nijak nemění, je pouze třeba je vrátit zpět
            return _values;
        }
    }
}