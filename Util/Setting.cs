using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProjectShell
{
    class Setting
    {
        public string Environment { get; set; } = ConfigurationManager.AppSettings["Environment"];
        public string Facility { get; set; } = ConfigurationManager.AppSettings["Facility"];
        public string ResidentFirstName { get; set; } = ConfigurationManager.AppSettings["ResidentFirstName"];
        public string ResidentLastName { get; set; } = ConfigurationManager.AppSettings["ResidentLastName"];
        public IWebDriver WebDriver { get; set; }
        public string Username { get; set; } = ConfigurationManager.AppSettings["Username"];
        public string Password { get; set; } = ConfigurationManager.AppSettings["Password"];
        public string Action { get; set; }

        public bool isExcelDataAvailable { get; set; } = false;

        public Setting(string[] args)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("disable-infobars", "start-maximized", "--ignore-certificate-errors", "--ignore-ssl-errors");
            chromeOptions.AddExcludedArgument("enable-automation");
            WebDriver = new ChromeDriver(chromeOptions);

            foreach (var arg in args)
            {
                string argType = Utility.GetUntilOrEmpty(arg);
                string argValue = arg.Substring(arg.LastIndexOf("#") + 1);

                if (argType.Equals(ArgTypes.Page.Value))
                {
                    this.Action = argValue;
                }
                else if (argType.Equals(ArgTypes.Username.Value))
                {
                    this.Username = argValue;
                }
                else if (argType.Equals(ArgTypes.Password.Value))
                {
                    this.Password = argValue;
                }
                else if (argType.Equals(ArgTypes.FirstName.Value))
                {
                    this.ResidentFirstName = argValue;
                }
                else if (argType.Equals(ArgTypes.LastName.Value))
                {
                    this.ResidentLastName = argValue;
                }
                else if (argType.Equals(ArgTypes.Facility.Value))
                {
                    this.Facility = argValue.Replace("_", " ");
                }
                else if (argType.Equals(ArgTypes.Environment.Value))
                {
                    //this.Environment = argValue;
                }
                else if (argType.Equals(ArgTypes.ExcelData.Value))
                {
                    this.Environment = argValue;
                }
            }
        }

        public Setting(ApplicationData applicationData)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("disable-infobars", "start-maximized", "--ignore-certificate-errors", "--ignore-ssl-errors");
            chromeOptions.AddExcludedArgument("enable-automation");
            WebDriver = new ChromeDriver(chromeOptions);
            this.Action = applicationData.Action;
            this.Environment = applicationData.Environment;
            this.Facility = applicationData.Facility.Replace("_", " ");
            this.Password = applicationData.Password;
            this.Username = applicationData.Username;
            this.ResidentFirstName = applicationData.ResidentFirstName;
            this.ResidentLastName = applicationData.ResidentLastName;
        }
    }

    public class SNFPages
    {
        private SNFPages(string value) { Value = value; }
        public string Value { get; set; }
        public static SNFPages ViewPrescriptionDrugOrder { get { return new SNFPages("ViewPrescriptionDrugOrder"); } }
        public static SNFPages CreateCustomDrugOrder { get { return new SNFPages("CreateCustomDrugOrder"); } }
        public static SNFPages ViewCancelRxResponseReport { get { return new SNFPages("ViewCancelRxResponseReport"); } }
    }
}
