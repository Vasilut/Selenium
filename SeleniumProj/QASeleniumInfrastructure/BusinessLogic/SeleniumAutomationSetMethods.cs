using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumInfrastructure
{
    public class SeleniumAutomationSetMethods : ISeleniumAutomationSetMethods
    {
        private IWebDriver _driver;
        public SeleniumAutomationSetMethods(IWebDriver driver)
        {
            _driver = driver;
        }
        public void Click(string element, PropertyType elementType)
        {
            if (elementType == PropertyType.Id)
            {
                _driver.FindElement(By.Id(element)).Click();
            }
            if (elementType == PropertyType.Name)
            {
                _driver.FindElement(By.Name(element)).Click();
            }
            if (elementType == PropertyType.LinkText)
            {
                _driver.FindElement(By.LinkText(element)).Click();
            }
        }

        public void EnterText(string element, string value, PropertyType elementType)
        {
            if (elementType == PropertyType.Id)
            {
                _driver.FindElement(By.Id(element)).SendKeys(value);
            }
            if (elementType == PropertyType.Name)
            {
                _driver.FindElement(By.Name(element)).SendKeys(value);
            }
            if (elementType == PropertyType.LinkText)
            {
                _driver.FindElement(By.LinkText(element)).SendKeys(value);
            }
        }
    }
}
