using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASeleniumInfrastructure
{
    public static class WebDriverFactory
    {
        public static IWebDriver GetDriver(string driverType)
        {
            switch (driverType)
            {
                case "chrome":
                    {
                        return new ChromeDriver();
                    }
                case "firefox":
                    {
                        return new FirefoxDriver();
                    }
                case "ie":
                    {
                        return null; //need to be implemented
                    }

                default:
                    break;
            }
            return null;
        }
    }
}
