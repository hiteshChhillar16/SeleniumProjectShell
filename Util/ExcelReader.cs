using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProjectShell
{
    static class ExcelReader
    {
        public static List<ApplicationData> ReadData()
        {
            List<ApplicationData> applicationDatas;
            String filePath = ConfigurationManager.AppSettings["ExcelDataFileLocation"];
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {

            using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    applicationDatas = result.Tables["UserInfo"].AsEnumerable()
                                            .Select(dataRow => new ApplicationData
                                            {
                                                Action = dataRow.Field<string>("Action"),
                                                Environment = dataRow.Field<string>("Environment"),
                                                Facility = dataRow.Field<string>("Facility"),
                                                Password = dataRow.Field<string>("Password"),
                                                ResidentFirstName = dataRow.Field<string>("ResidentFirstName"),
                                                ResidentLastName = dataRow.Field<string>("ResidentLastName"),
                                                Username = dataRow.Field<string>("Username")
                                            }).ToList();

                }

            }

            return (applicationDatas==null) ? new List<ApplicationData>() : applicationDatas;
        }
    }
}
