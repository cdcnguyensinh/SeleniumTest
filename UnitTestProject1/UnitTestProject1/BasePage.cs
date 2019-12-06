using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
