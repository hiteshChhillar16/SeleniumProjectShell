using OpenQA.Selenium;
using System;

namespace SeleniumProjectShell
{
    class ApplicationSeleniumSetup
    {
        public static void Login(Setting appSettings)
        {
            appSettings.WebDriver.Navigate().GoToUrl(appSettings.Environment + "/");
            try
            {
                //this code is only for exceptions stuff
                IWebElement securityCheck = appSettings.WebDriver.FindElement(By.Id("details-button"));
                appSettings.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                securityCheck.Click();
                appSettings.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
                IWebElement proceedLink = appSettings.WebDriver.FindElement(By.Id("proceed-link"));
                proceedLink.Click();
            }
            catch (Exception exUseless)
            {
                //no need to do anything;
            }

            appSettings.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement username = appSettings.WebDriver.FindElement(By.Id("username"));
            username.SendKeys(appSettings.Username);

            IWebElement password = appSettings.WebDriver.FindElement(By.Id("password"));
            password.SendKeys(appSettings.Password);

            IWebElement signIn;
            signIn = appSettings.WebDriver.FindElement(By.Id("loginButton"));

            signIn.Click();
        }
    }
}
