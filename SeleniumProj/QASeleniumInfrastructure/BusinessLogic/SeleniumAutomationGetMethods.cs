using OpenQA.Selenium;
using QASeleniumInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumInfrastructure.BusinessLogic
{
    public class SeleniumAutomationGetMethods : ISeleniumAutomationGetMethods
    {
        private IWebDriver _driver;
        public SeleniumAutomationGetMethods(IWebDriver driver)
        {
            _driver = driver;
        }
        public string GetText(string element, PropertyType elementType)
        {
            if(elementType == PropertyType.Id)
            {
                return _driver.FindElement(By.Id(element)).Text;
            }
            if(elementType == PropertyType.Name)
            {
                return _driver.FindElement(By.Name(element)).Text;
            }

            return string.Empty;
        }
    }
}
