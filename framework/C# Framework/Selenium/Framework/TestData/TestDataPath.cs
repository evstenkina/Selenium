using System.IO;

namespace Selenium.Framework
{
    public class TestDataPath
    {
        public static string UserForRegistrationPath = Path.Combine(TestDataConstats.BaseDirectoryPath, TestDataConstats.TestDataPath, TestDataConstats.UsersForRegistrationTestData);
        //public static string ScreenshotsPath = Path.Combine(TestDataConstats.BaseDirectoryPath, TestDataConstats.TestDataPath, TestDataConstats.Screenshots);
        public static string ScreenshotsPath = Path.Combine(TestDataConstats.BaseDirectoryPath,TestDataConstats.Screenshots);
        public const string ImagePath =
            "/Users/yevheniiastenkina/RiderProjects/estenkina-aut15/framework/C# Framework/Selenium/Image.jpg";

        public const string IconPath =
            "/Users/yevheniiastenkina/RiderProjects/estenkina-aut15/framework/C# Framework/Selenium/Icon.jpeg";
    }
}