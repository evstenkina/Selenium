using System;
using System.IO;

namespace Selenium.Framework
{
    public class TestDataConstats
    {
        public static readonly string BaseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        
        public const string TestDataPath = "Framework/TestData";
        public const string UsersForRegistrationTestData = "RegisterUsers.csv";
        public const string Screenshots = "Screenshots";
    }
}