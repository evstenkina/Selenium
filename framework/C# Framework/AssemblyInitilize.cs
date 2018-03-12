    using System.IO;
    using log4net.Config;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

public class AssemblyInitilize
    {
        [AssemblyInitialize]
        public static void Configure(TestContext tc)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.properties"));
        }
    }
