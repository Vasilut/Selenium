using CalendisReservationAutomatically.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendisReservationAutomatically.Services
{
    public class Validator : IValidator
    {
        public bool VerifDay(string day, List<string> days)
        {
            return days.Contains(day);
        }

        public bool VerifHour(string hour, List<string> hours)
        {
            return hours.Contains(hour);
        }
    }
}
