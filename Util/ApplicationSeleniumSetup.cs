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
            IWebElement username = appSettings.WebDriver.FindElement(By.Id("j_username"));
            username.SendKeys(appSettings.Username);

            IWebElement password = appSettings.WebDriver.FindElement(By.Id("j_password"));
            password.SendKeys(appSettings.Password);

            IWebElement signIn;
            if (appSettings.Environment.Contains("qa17"))
            {
                signIn = appSettings.WebDriver.FindElement(By.Id("loginSubmit"));
            }
            else
            {
                signIn = appSettings.WebDriver.FindElement(By.Id("loginbtn"));
            }

            signIn.Click();
        }

        public static void SetFacility(Setting appSettings)
        {
            string facilityTitleText;
            IWebElement facilityTitleName;
            try
            {
                facilityTitleName = appSettings.WebDriver.FindElement(By.XPath("/html/body/div/div[3]/span[3]/a"));
                facilityTitleText = facilityTitleName.Text;
            }
            catch (Exception ex)
            {
                facilityTitleText = "";
            }
            if (facilityTitleText == "" || !appSettings.Facility.Contains(facilityTitleText))
            {

                //If different facility is selected then clean up textbox and search for our facility
                IWebElement facilitySearchTextbox = appSettings.WebDriver.FindElement(By.Name("facility_name"));
                facilitySearchTextbox.Clear();
                facilitySearchTextbox.SendKeys(appSettings.Facility);
                IWebElement searchFacilityButton = appSettings.WebDriver.FindElement(By.Name("search"));
                searchFacilityButton.Click();
                IWebElement facilityItem = appSettings.WebDriver.FindElement(By.PartialLinkText(appSettings.Facility));
                facilityItem.Click();
            }

            SetResident(appSettings);
        }

        public static void SetResident(Setting appSettings)
        {
            appSettings.WebDriver.Navigate().GoToUrl(appSettings.Environment + "/Zion?zionpagealias=SELECTPATIENT");

            IWebElement lastNameResidentSearch = appSettings.WebDriver.FindElement(By.Id("LastName"));
            IWebElement firstNameResidentSearch = appSettings.WebDriver.FindElement(By.Name("FirstName"));

            lastNameResidentSearch.Clear();
            firstNameResidentSearch.Clear();
            lastNameResidentSearch.SendKeys(appSettings.ResidentLastName);
            firstNameResidentSearch.SendKeys(appSettings.ResidentFirstName);
            IWebElement searchResident = appSettings.WebDriver.FindElement(By.Name("Search"));
            searchResident.Click();

            IWebElement residentElement = appSettings.WebDriver.FindElement(By.XPath("//*[@id='patientList']/table/tbody/tr/td[1]/a"));

            residentElement.Click();
        }
    }
}
