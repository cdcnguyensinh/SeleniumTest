using OpenQA.Selenium.Chrome;

namespace SICorp.Test
{
    public abstract class BasePage
    {
        protected ChromeDriver chromeDriver;

        public BasePage(ChromeDriver driver)
        {
            chromeDriver = driver;
        }
    }
}
