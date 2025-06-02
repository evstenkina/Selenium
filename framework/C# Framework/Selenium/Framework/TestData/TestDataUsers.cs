namespace Selenium.Framework.TestData
{
    public class TestDataUsers
    {
        public const string UserRole = "user";
    
        public const string DeveloperRole = "developer";

        public static User GetDefaultUser()
        {
            return new User { Login = "admin", Password = "admin", FirstName = "Ivan", LastName = "Petrov" };
        }
    
        public static User GetInvalidUser()
        {
            return new User { Login = "admin", Password = "invalid", FirstName = "Ivan", LastName = "Petrov" };
        }

        public static User GetStenkinaUser()
        {
            return new User { FirstName = "Yevheniia", LastName = "Stenkina", Password = "123", Login = "Yevheniia", Role = UserRole };
        }
    
        public static User GetStenkinaDeveloper()
        {
            return new User { FirstName = "Zenya", LastName = "Stenkina", Password = "321", Role = DeveloperRole };
        }
    }
}