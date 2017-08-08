using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendisReservationAutomatically.Services.Interfaces
{
    public interface IWeekProcessing
    {
        bool ProcessWeek(List<IWebElement> goodDays, IWebDriver driver, List<string> hours, List<string> days);
    }
}
