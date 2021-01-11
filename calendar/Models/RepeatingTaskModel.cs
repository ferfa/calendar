using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.Models
{
    public class RepeatingTaskModel : ObservableObject
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public RepeatingTaskModel(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }
    }
}
