using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Selenium.Framework.Models;

namespace Selenium.Framework.Helpers
{
    public static class CsvReaderHelper
    {
        public static List<User> ReadUsersFromCsv(string filePath)
        {
            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<User>().ToList();
        }
    }
}