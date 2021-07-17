using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProjectShell
{
    class FacilityReports
    {
        public static void ViewFaciltyReportPage(Setting appSettings, ApplicationData data)
        {
            string url = appSettings.Environment + ConfigurationManager.AppSettings["FacilityReportsUrl"];
            appSettings.WebDriver.Navigate().GoToUrl(url);
        }

        public static void ViewCancelRxResponseReport(Setting setting, ApplicationData data)
        {
            ViewFaciltyReportPage(setting, data);

            IWebElement reportRadioButton = setting.WebDriver.FindElement(By.Id("ReportRadio549505918"));
            reportRadioButton.Click();

            IWebElement nextButton = setting.WebDriver.FindElement(By.Name("Submit"));
            nextButton.Click();


            //IWebElement pharmacyResponse = setting.WebDriver.FindElement(By.Id("Pharmacy Response"));
            //var pharmacyResponseSelections = new SelectElement(pharmacyResponse);
            //pharmacyResponseSelections.SelectByValue("Approved");
            //pharmacyResponseSelections.SelectByValue("Approved");

            IWebElement responseMatching = setting.WebDriver.FindElement(By.Id("Response Matching"));
            var responseSelections = new SelectElement(responseMatching);
            responseSelections.SelectByValue("Not Matched");

            IWebElement reportButton = setting.WebDriver.FindElement(By.Name("Submit"));
            reportButton.Click();
        }
    }
}
