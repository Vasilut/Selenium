using System.Collections.Generic;

namespace CalendisReservationAutomatically.Services.Interfaces
{
    public interface IValidator
    {
        bool VerifHour(string hour, List<string> hours);
        bool VerifDay(string day, List<string> days);
    }
}
