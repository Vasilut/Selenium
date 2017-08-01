using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProj
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver _driver;

        [TestInitialize]
        public void InitClient()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://192.168.111.196/prophet/admin/saas/main.aspx");
        }

        [TestMethod]
        [ExpectedException(typeof(System.EntryPointNotFoundException))]
        public void Login()
        {

            //Find the element
            IWebElement name = _driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:tb_Email"));
            IWebElement password = _driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:tb_Password"));
            IWebElement loginButton = _driver.FindElement(By.Name("_ctl0:ContentPlaceHolder1:btn_signin"));


            //Perform ops
            name.SendKeys("lucian.vasilut10@gmail.com");
            password.SendKeys("11111");
            loginButton.SendKeys(Keys.Enter);

            //Find the login user
            IWebElement userLoggedIn = _driver.FindElement(By.Id("Top1_lblFirstNM"));
            var userName = userLoggedIn.Text;
            Assert.IsTrue(userName == "Lucian");

            //Make logout
            _driver.Navigate().GoToUrl("http://192.168.111.196/prophet/admin/saas/logout.aspx");

            IWebElement userLoggedInAfterLogout = _driver.FindElement(By.Id("Top1_lblFirstNM"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
