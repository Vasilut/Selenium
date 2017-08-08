using System;
using System.Collections.Generic;
using CalendisReservationAutomatically.Services.Interfaces;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;

namespace CalendisReservationAutomatically.Services
{
    public class WeekProcessing : IWeekProcessing
    {
        private IValidator _validator;

        public WeekProcessing(IValidator validator)
        {
            _validator = validator;
        }
        public bool ProcessWeek(List<IWebElement> goodDays, IWebDriver driver, List<string> hours, List<string> days)
        {
            bool ok = false; //we don't have yet a reservation
            for (int i = 0; i < goodDays.Count && !ok; ++i)
            {
                string day = goodDays[i].Text;
                goodDays[i].Click();
                Thread.Sleep(2000);
                //var div = driver.FindElement(By.ClassName("appointment-timeline"));
                var div2 = driver.FindElement(By.Id("appointment-maker"));
                var lists = div2.FindElements(By.TagName("li")).ToList();
                //var lists = div.FindElements(By.TagName("li")).ToList();
                for (int j = 0; j < lists.Count; ++j)
                {
                    if (_validator.VerifHour(lists[j].Text, hours))
                    {
                        string hour = lists[j].Text;
                        //make reservation at this hour
                        lists[j].Click();

                        //press the button next step
                        var nextStepButton = driver.FindElement(By.Id("btn-appointment-step2"));
                        nextStepButton.Click();
                        Thread.Sleep(1500);

                        //check the checkbox
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(By.Id("regulations-checkbox")));
                        Thread.Sleep(1500);

                        //make the final submit
                        var finalButton = driver.FindElement(By.Id("booking-final-submit"));
                        finalButton.Click();
                        Console.WriteLine($"Rezervarea a fost facuta in ziua {day} la ora {hour}");

                        ok = true;
                        break;
                    }
                }
            }
            return ok;
        }
    }
}
