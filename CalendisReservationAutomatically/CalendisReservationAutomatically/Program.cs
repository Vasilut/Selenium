using CalendisReservationAutomatically.Constants;
using CalendisReservationAutomatically.Services;
using CalendisReservationAutomatically.Services.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CalendisReservationAutomatically
{
    class Program
    {
        static void Main(string[] args)
        {

            //init driver
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Constant.CalendisUrl);

            //logIn
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", driver.FindElement(By.Id("loginLink")));

            //login
            IWebElement email = driver.FindElement(By.Name("email"));
            email.SendKeys(Constant.Email);
            IWebElement password = driver.FindElement(By.Name("password"));
            password.SendKeys(Constant.Password);

            //login button
            IWebElement logginButton = driver.FindElement(By.TagName("button"));
            logginButton.Click();

            //We are logged in the system. Start the party.
            //we're logged in, so we can proceed directly to this link :P (footbal, tennis, baschet).
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl(Constant.SportLink);

            //create the reservation
            //create reservation button
            IWebElement createReservationButton = driver.FindElement(By.Id("make-appointment-btn"));
            createReservationButton.Click();

            List<string> goodHours = Constant.GoodHours.Split(' ').ToList();

            IValidator validator = new Validator();
            IWeekProcessing weekProcessing = new WeekProcessing(validator);
            IReservationProceed reservationProceed = new ReservationProceed(weekProcessing);
            reservationProceed.MakeReservation(driver, goodHours, new List<string>());
            

            Console.WriteLine("Press any key to continue....");
            Console.ReadLine();
        }
        
    }
}
