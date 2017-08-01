using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProj
{
    public class Program
    {
        //create the reference for our browser
        IWebDriver driver = new ChromeDriver();

        static void Main(string[] args)
        {
            ////create the reference for our browser
            IWebDriver driver = new ChromeDriver();

            //navigate to a page
            driver.Navigate().GoToUrl("http://192.168.111.196/prophet/admin/saas/main.aspx");

            //Find the element
            IWebElement name = driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:tb_Email"));
            IWebElement password = driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:tb_Password"));
            IWebElement loginButton = driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:btn_signin"));


            //Perform ops
            name.SendKeys("lucian.vasilut10@gmail.com");
            password.SendKeys("11111");
            loginButton.SendKeys(Keys.Enter);

            //Find the login user
            IWebElement userLoggedIn = driver.FindElement(By.Id("Top1_lblFirstNM"));
            var userName = userLoggedIn.Text;

            var x = 2;
            IWebElement logOutButton = driver.FindElement(By.LinkText("Logout"));

            driver.Close();
            driver.Quit();
        }

        [SetUp]
        public void Initialize()
        {
            //navigate to a page
            driver.Navigate().GoToUrl("https://www.prophetondemand.com/prophet/admin/");
        }

        [Test]
        public void ExecuteTest()
        { 
            //Find the element
            IWebElement name = driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:tb_Email"));
            IWebElement password = driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:tb_Password"));
            IWebElement loginButton = driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:btn_signin"));


            //Perform ops
            name.SendKeys("lucian.vasilut10@gmail.com");
            password.SendKeys("11111");
            loginButton.SendKeys(Keys.Enter);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
            //driver.Close();
        }

    }
}
