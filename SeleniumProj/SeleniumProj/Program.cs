using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProj
{
    class Program
    {
        static void Main(string[] args)
        {
            //create the reference for our browser
            IWebDriver driver = new ChromeDriver();

            //navigate to a page
            driver.Navigate().GoToUrl("http://192.168.111.196/prophet/admin/login.aspx");

            //Find the element
            IWebElement name = driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:tb_Email"));
            IWebElement password = driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:tb_Password"));
            IWebElement loginButton = driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:btn_signin"));


            //Perform ops
            name.SendKeys("lucian.vasilut10@gmail.com");
            password.SendKeys("11111");
            loginButton.SendKeys(Keys.Enter);


            driver.Quit();
        }
    }
}
