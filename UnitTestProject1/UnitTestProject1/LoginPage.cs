using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICorp.Test
{
    public class LoginPage : BasePage
    {
        const string PasswordId = "in_pw_userpass";
        const string UsernameId = "pt-login-username-textbox";
        By Password = By.Id(PasswordId);
        By Username = By.Id(UsernameId);

        public LoginPage(ChromeDriver driver) : base(driver)
        {

        }

        private void SetUsername(string username)
        {
            var usernameElement = chromeDriver.FindElement(Username);
            usernameElement.SendKeys(username);
        }

        private void SetPassword(string password)
        {
            var passwordElement = chromeDriver.FindElement(Password);
            passwordElement.SendKeys(password);
        }

        private void Submit()
        {
            var passwordElement = chromeDriver.FindElement(Password);       
            passwordElement.SendKeys(Keys.Enter);
        }

        public void Login(string username, string password)
        {
            SetUsername(username);
            SetPassword(password);         
            Submit();
        }
    }
}
