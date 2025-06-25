using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Selenium.Framework.Helpers
{
    public class CSVReaderHelper
    {
        public List<User> ReadUsersFromCsv(string a) //todo to helper
        {
            var reader = new StreamReader(a);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<User>().ToList();
        }
    }
}