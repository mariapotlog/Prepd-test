using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Prepd
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By login = By.XPath("//*[@id='no-login-mobile']/a");
        private IWebElement BtnLogIn()
        {
            return driver.FindElement(login);
        }
        public void NavigateToLoginPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(login));
            BtnLogIn().Click();
            
        }
        //
        private By email = By.XPath("/html/body/library-root/library-login/pp-login/pp-flex/pp-flex/form/pp-body/pp-flex[1]/input[1]");
        private IWebElement TxtUserEmail()
        {
            return driver.FindElement(email);
        }

        private By password = By.XPath("/html/body/library-root/library-login/pp-login/pp-flex/pp-flex/form/pp-body/pp-flex[1]/input[2]");
        private IWebElement TxtPassword()
        {
            return driver.FindElement(password);
        }

        private By btnlogin = By.XPath("/html/body/library-root/library-login/pp-login/pp-flex/pp-flex/form/pp-body/pp-flex[2]/button");
        private IWebElement BtnLogin()
        {
            return driver.FindElement(btnlogin);
        }
        public void LoginApplication(string username, string password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(35));
            wait.Until(ExpectedConditions.ElementIsVisible(btnlogin));
            TxtUserEmail().SendKeys(username);
            TxtPassword().SendKeys(password);
            BtnLogin().Click();
        }

        private By AccountPictogram => By.XPath("/html/body/library-root/library-dashboard/pp-dashboard/pp-header/div/div/img");
        private IWebElement AccountPictogramElem()
        {
            return driver.FindElement(AccountPictogram);
        }

        private By AccountName => By.XPath("/html/body/library-root/library-dashboard/pp-dashboard/pp-dashboard-user-menu/div[2]/div[1]");
        private IWebElement AccountNameHeader()
        {
            return driver.FindElement(AccountName);
        }
        public string AccountNameText => AccountNameHeader().Text;

        public void AssertLoginTest(string expectedResult)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(35));
            wait.Until(ExpectedConditions.ElementExists(AccountPictogram));
            AccountPictogramElem().Click();
            Assert.AreEqual(expectedResult, AccountNameText);
        }
    }
}
