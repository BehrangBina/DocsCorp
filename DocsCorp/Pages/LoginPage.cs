using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace DocsCorp.Pages
{
    public class LoginPage
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
        }
        private IWebElement UserNameTextBox
        {
            get
            {
                By userNameText = By.XPath("//input[@name='session[username_or_email]']");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(userNameText));
            }
        }
        private IWebElement UserPasswordTextBox
        {
            get
            {
                By userPasswordText = By.XPath("//input[@name='session[password]']");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(userPasswordText));

            }
        }
        private IWebElement loginButton
        {
            get
            {
                By loginButton = By.XPath("//div[@role='button']");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(loginButton));
            }
        }
        public void InputUserName(string userName) => UserNameTextBox.SendKeys(userName);


        public void InputPassword(string password) => UserPasswordTextBox.SendKeys(password);

        public void ClickLogin() => loginButton.Click();
    }
}
