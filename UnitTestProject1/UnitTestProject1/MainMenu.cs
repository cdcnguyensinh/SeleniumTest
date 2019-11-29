using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SICorp.Test
{
    public class MainMenu : BasePage
    {        
        By distributorsMenu = By.XPath("//*[@id=\"menu-main\"]/li[1]/ul/li[2]");
        By beatMenu = By.XPath("//*[@id=\"menu-main\"]/li[1]/ul/li[2]/ul/li/section/div/div/div/ul/li[4]");
        By launchBeat = By.XPath("//*[@id=\"pt-portlet-content-461\"]/div/a");

        public MainMenu(ChromeDriver driver) : base(driver)
        {

        }

        public void GoBeatPage()
        {
            Util.WaitForMainMenu(chromeDriver);

            var distributorsSubMenu = Util.WaitUntilElementExists(chromeDriver, distributorsMenu, 10);
            Actions action = new Actions(chromeDriver);
            action.MoveToElement(distributorsSubMenu).Perform();

            Thread.Sleep(2000);

            var beatSubMenu = Util.WaitUntilElementExists(chromeDriver, beatMenu, 10);
            beatSubMenu.Click();
        }

        public void LaunchBeat()
        {
            Thread.Sleep(2000);
            var launchBeatLink = Util.WaitUntilElementExists(chromeDriver, launchBeat, 10);
            launchBeatLink.Click();
        }
    }
}
