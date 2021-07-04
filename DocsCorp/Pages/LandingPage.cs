using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DocsCorp.Pages
{
    class LandingPage
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        public LandingPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        private IWebElement LoginButton
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
                By loginLocation = By.LinkText("Log in");
                IWebElement loginLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(loginLocation));
                return loginLink;
            }
        }

    
        public void ClickOnLogin()
        {
            LoginButton.Click();
        }
    }
}
