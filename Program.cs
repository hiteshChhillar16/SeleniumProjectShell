using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProjectShell
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ApplicationData> applicationDatas = ExcelReader.ReadData();

            //foreach record perform the certain action
            foreach(var appData in applicationDatas)
            {
                Setting appSetting = new Setting(appData);
                ApplicationSeleniumSetup.Login(appSetting);
            }

        }
    }
}
