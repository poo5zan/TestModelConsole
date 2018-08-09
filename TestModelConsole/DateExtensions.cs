using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelConsole
{
    public static class DateExtensions
    {
        public static string GetEndOfWeekDate(this DateTime dateTime, string dateFormat = "MM/dd/yyyy")
        {
            var startOfWeek = dateTime.AddDays(-(int)dateTime.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);
            return endOfWeek.ToString(dateFormat);
        }
    }
}
