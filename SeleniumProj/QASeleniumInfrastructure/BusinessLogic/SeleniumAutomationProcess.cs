using OpenQA.Selenium;
using QASeleniumInfrastructure.BusinessLogic;
using QASeleniumInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumInfrastructure
{
    public class SeleniumAutomationProcess : ISeleniumAutomationProcess
    {
        private IWebDriver _driver;
        private ISeleniumAutomationSetMethods _seleniumAutomationSetMethods;
        private ISeleniumAutomationGetMethods _seleniumAutomationGetMethods;
        public SeleniumAutomationProcess(string driverType)
        {
            _driver = WebDriverFactory.GetDriver(driverType);

            //TBD import a DI frameword
            _seleniumAutomationSetMethods = new SeleniumAutomationSetMethods(_driver);
            _seleniumAutomationGetMethods = new SeleniumAutomationGetMethods(_driver);
        }
        public void Click(string element, PropertyType elementType)
        {
            _seleniumAutomationSetMethods.Click(element, elementType);
        }
        
        public void EnterText(string element, string value, PropertyType elementType)
        {
            _seleniumAutomationSetMethods.EnterText(element, value, elementType);
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public dynamic GetElement(string element, PropertyType elementType)
        { 
            //TBD extract in a interface
            if (elementType == PropertyType.Id)
            {
                return _driver.FindElement(By.Id(element));
            }
            if (elementType == PropertyType.Name)
            {
                return _driver.FindElement(By.Name(element));
            }
            if (elementType == PropertyType.LinkText)
            {
                return _driver.FindElement(By.LinkText(element));
            }

            return null;
        }


        public string GetText(string element, PropertyType elementType)
        {
            return _seleniumAutomationGetMethods.GetText(element, elementType);
        }

        public void CloseDriver()
        {
            _driver.Close();
            _driver.Quit();
        }

    }
}
