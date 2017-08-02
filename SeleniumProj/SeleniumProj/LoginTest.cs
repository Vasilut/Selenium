using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QASeleniumInfrastructure;
using System;
using System.IO;

namespace SeleniumProj
{
    [TestClass]
    public class LoginTest
    {
        private ISeleniumAutomationProcess _seleniumAutomationProcess;

        [TestInitialize]
        public void InitClient()
        {
            _seleniumAutomationProcess = new SeleniumAutomationProcess("chrome");
            _seleniumAutomationProcess.Navigate("http://192.168.111.196/prophet/admin/saas/main.aspx");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void Login()
        {
            //InitElements
            _seleniumAutomationProcess.EnterText("_ctl0:ContentPlaceHolder1:tb_Email", Constants.Constants.UserName, PropertyType.Name); //userName
            _seleniumAutomationProcess.EnterText("_ctl0:ContentPlaceHolder1:tb_Password", Constants.Constants.Password, PropertyType.Name); //Password
            _seleniumAutomationProcess.EnterText("_ctl0:ContentPlaceHolder1:btn_signin", Keys.Enter, PropertyType.Name); //LoginButton

            //Get the login user
            string userNameLoggedIn = _seleniumAutomationProcess.GetText("Top1_lblFirstNM", PropertyType.Id);
            Assert.IsTrue(userNameLoggedIn == "Lucian");

            //Make LogOut
            _seleniumAutomationProcess.Click("Logout", PropertyType.LinkText);
            _seleniumAutomationProcess.GetElement("Top1_lblFirstNM", PropertyType.Id);
        }


        [TestCleanup]
        public void CleanUp()
        {
            _seleniumAutomationProcess.CloseDriver();
        }
    }
}
