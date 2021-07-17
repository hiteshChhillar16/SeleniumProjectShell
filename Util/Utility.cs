using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProjectShell
{
    static class Utility
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = "#")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
    }

    public class ArgTypes
    {
        private ArgTypes(string value) { Value = value; }
        public string Value { get; set; }
        public static ArgTypes Page { get { return new ArgTypes("pg"); } }
        public static ArgTypes FirstName { get { return new ArgTypes("rfn"); } }
        public static ArgTypes LastName { get { return new ArgTypes("rln"); } }
        public static ArgTypes Username { get { return new ArgTypes("un"); } }
        public static ArgTypes Password { get { return new ArgTypes("pd"); } }
        public static ArgTypes Environment { get { return new ArgTypes("env"); } }
        public static ArgTypes Facility { get { return new ArgTypes("fc"); } }
        public static ArgTypes ExcelData { get { return new ArgTypes("excelData"); } }

    }
}
