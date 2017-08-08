using CalendisReservationAutomatically.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CalendisReservationAutomatically.Services
{
    public class ReservationProceed : IReservationProceed
    {
        private IWeekProcessing _weekProcessing;

        public ReservationProceed(IWeekProcessing weekProcessing)
        {
            _weekProcessing = weekProcessing;
        }
        public void MakeReservation(IWebDriver driver, List<string> hours, List<string> days)
        {
            int step = 2;
            while (step > 0)
            {
                --step;
                //see if we have done a reservation this week
                int reservationExists = 0;
                reservationExists = driver.FindElements(By.ClassName("appointment-timeline-no-slots")).ToList().Count;

                if (reservationExists > 0)
                {
                    //we reserved this week so we need to go to next week.
                    //go to the next week and start searching for a good value
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector(".glyphicon-chevron-right"))); //go next week
                    var allDays = driver.FindElements(By.ClassName("calendar-item")).ToList();
                    bool ok = _weekProcessing.ProcessWeek(allDays, driver, hours,days);
                    if (ok == false)
                    {
                        //go to the next week and start searching for a good value
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector(".glyphicon-chevron-right"))); //go next week
                    }
                    else
                    {
                        step = 0;
                    }
                }
                else
                {
                    //search on current weeek
                    //get all active days
                    //var xx = driver.FindElements(By.XPath("//div[contains(@class, 'calendar-item') and contains(@class, 'disabled-day')]")).ToList();
                    //var activeDays = driver.FindElements(By.CssSelector("div[class='calendar-item disabled-day']")).ToList();

                    var allDays = driver.FindElements(By.ClassName("calendar-item")).ToList();
                    var disabledDays = driver.FindElements(By.ClassName("disabled-day")).ToList();
                    List<IWebElement> goodDays = GetActiveDays(allDays, disabledDays);

                    bool ok = _weekProcessing.ProcessWeek(goodDays, driver,hours,days);
                    if (ok == false)
                    {
                        //go to the next week and start searching for a good value
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(By.CssSelector(".glyphicon-chevron-right"))); //go next week
                    }
                    else
                    {
                        step = 0;
                    }
                }
            }
        }

        private List<IWebElement> GetActiveDays(List<IWebElement> allDays, List<IWebElement> disabledDays)
        {
            List<IWebElement> goodDays = new List<IWebElement>();

            for (int i = 0; i < allDays.Count; ++i)
            {
                bool isDisabledDay = true;
                for (int j = 0; j < disabledDays.Count && isDisabledDay; ++j)
                {
                    if (allDays[i].Text == disabledDays[j].Text)
                    {
                        isDisabledDay = false;
                    }
                }

                if (isDisabledDay)
                {
                    //good day
                    goodDays.Add(allDays[i]);
                }
            }
            return goodDays;
        }
    }
}
