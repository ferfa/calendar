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
        private EntryModel _entry;
        private DateTime _date;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            _entry = (EntryModel)values[0];
            _date = (DateTime)values[1];

            if (_entry.Completed.Contains(_date))
            {
                return true;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                _entry.Complete(_date);
            }
            else
            {
                _entry.Uncomplete(_date);
            }

            object[] ret = new object[2];
            ret[0] = _entry;
            ret[1] = _date;

            return ret;
        }
    }
}