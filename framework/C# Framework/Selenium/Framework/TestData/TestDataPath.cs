using System.IO;

namespace Selenium.Framework
{
    public class TestDataPath
    {
        public static string UserForRegistrationPath = Path.Combine(TestDataConstats.BaseDirectoryPath, TestDataConstats.TestDataPath, TestDataConstats.UsersForRegistrationTestData);

        public static string ScreenshotsPath = Path.Combine(TestDataConstats.BaseDirectoryPath,TestDataConstats.TestDataPath, TestDataConstats.Screenshots);

        public static readonly string ImagePath = Path.Combine(TestDataConstats.BaseDirectoryPath, TestDataConstats.TestDataPath, TestDataConstats.Image);

        public static readonly string IconPath = Path.Combine(TestDataConstats.BaseDirectoryPath, TestDataConstats.TestDataPath, TestDataConstats.Icon);
    }
}