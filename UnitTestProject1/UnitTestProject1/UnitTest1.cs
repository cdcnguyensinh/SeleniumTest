using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using SICorp.Test.Builder;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ChromeDriver driver;
        BuilderPage builderPage;
        [TestMethod]
        public void TestMethod1()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-web-security");
            ////options.AddArgument("--user-data-dir=~/.e2e-chrome-profile");

            driver = new ChromeDriver(options);
            builderPage = new BuilderPage(driver);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://portal-uat.hbcf.nsw.gov.au/portal/server.pt?open=space&name=Login&control=Login&login=&in_hi_userid=953&cached=true");
            Assert.IsTrue(true);
        }
    }
}
