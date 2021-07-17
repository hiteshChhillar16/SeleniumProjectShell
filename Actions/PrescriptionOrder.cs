using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace SeleniumProjectShell
{
    class PrescriptionOrder
    {
        public static void CreateCustomPrescriptionOrder(Setting appSettings)
        {
            appSettings.WebDriver.Navigate().GoToUrl(appSettings.Environment + "/Zion?zionpagealias=ORDERHOME");
            IWebElement addOrder = appSettings.WebDriver.FindElement(By.Name("addOrder"));
            addOrder.Click();

            IWebElement orderType = appSettings.WebDriver.FindElement(By.Name("orderType"));
            var selectElement = new SelectElement(orderType);
            selectElement.SelectByText("Prescription");

            IWebElement provider = appSettings.WebDriver.FindElement(By.Name("PROVIDERID"));
            var selectProvider = new SelectElement(provider);
            try
            {
                selectProvider.SelectByText("Omnicare - OH1 - ---");
            }
            catch (Exception ex)
            {
                selectProvider.SelectByIndex(1);
            }
            IWebElement nextButton = appSettings.WebDriver.FindElement(By.Id("orderNextButton"));
            nextButton.Click();

            //check for popup about Drug allergies not been defined on the facesheet
            try
            {
                appSettings.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                IWebElement acceptDrugAllergiesPopup = appSettings.WebDriver.FindElement(By.Id("allergyAlertOkayButton"));
                acceptDrugAllergiesPopup.Click();
            }
            catch (Exception ex)
            {
                //no need to do anything expected catch condition.
            }
            appSettings.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement searchMedicineByText = appSettings.WebDriver.FindElement(By.Id("searchText"));
            searchMedicineByText.SendKeys("testMedicine");

            IWebElement searchMedicine = appSettings.WebDriver.FindElement(By.Id("search"));
            searchMedicine.Click();

            appSettings.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement customOrderButton = appSettings.WebDriver.FindElement(By.Name("customerOrderButton"));
            customOrderButton.Click();
        }

        public static void CreateAndFillCustomOrderDetails(Setting appSettings)
        {
            CreateCustomPrescriptionOrder(appSettings);
            appSettings.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement drugRecievedBy = appSettings.WebDriver.FindElement(By.Id("receivedById"));
            var receivedSelections = new SelectElement(drugRecievedBy);
            receivedSelections.SelectByIndex(2);

            IWebElement drugScheduled = appSettings.WebDriver.FindElement(By.Id("cSASchedule"));
            var drugScheduledSelections = new SelectElement(drugScheduled);
            drugScheduledSelections.SelectByValue("0");

            //Dialog opens
            IWebElement confirm = appSettings.WebDriver.FindElement(By.XPath("//*[@id='csDrugModal']/div/div/div/footer/button[1]"));
            confirm.Click();

            IWebElement drugForm = appSettings.WebDriver.FindElement(By.Id("form"));
            var drugFormSelections = new SelectElement(drugForm);
            drugFormSelections.SelectByValue("aerosol");

            IWebElement strength = appSettings.WebDriver.FindElement(By.Id("strength"));
            strength.SendKeys("1mg");

            try
            {
                IWebElement route = appSettings.WebDriver.FindElement(By.Id("route"));
                var routeSelections = new SelectElement(route);
                routeSelections.SelectByValue("compounding");
            }
            catch (Exception ex)
            {
                //log the exception but move ahead
            }

            try
            {
                IWebElement amount = appSettings.WebDriver.FindElement(By.Id("amount"));
                amount.SendKeys("1mg");
            }
            catch (Exception ex)
            {
                //log the exception but move ahead
            }

            try
            {
                IWebElement refill = appSettings.WebDriver.FindElement(By.Id("refill"));
                refill.SendKeys("0");
            }
            catch (Exception ex)
            {
                //log the exception but move ahead
            }


            IWebElement frequency = appSettings.WebDriver.FindElement(By.Id("frequencyUuid"));
            var frequencySelections = new SelectElement(frequency);
            frequencySelections.SelectByText("Once - One Time");

            IWebElement flowsheet = appSettings.WebDriver.FindElement(By.Id("flowsheetId"));
            var flowsheetSelections = new SelectElement(flowsheet);
            flowsheetSelections.SelectByText("Medications");

            IWebElement orderSource = appSettings.WebDriver.FindElement(By.Id("orderSourceId"));
            var orderSourceSelections = new SelectElement(orderSource);
            orderSourceSelections.SelectByText("Telephone");
        }

        public static void ViewScheduledOrder(Setting appSettings)
        {
            appSettings.WebDriver.Navigate().GoToUrl(appSettings.Environment + "/Zion?zionpagealias=ORDERHOME");
            IWebElement scheduledOrderLink = appSettings.WebDriver.FindElement(By.PartialLinkText("Schedule"));
            scheduledOrderLink.Click();
        }
    }
}
