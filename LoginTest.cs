using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Prepd
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://prepd.in/");
            loginPage.NavigateToLoginPage();
        }

        [TestMethod]
        public void Login()
        {
            loginPage.LoginApplication("maria.potlog@mailinator.com", "mp456789");
            loginPage.AssertLoginTest("Maria Potlog");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
