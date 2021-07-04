using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;

namespace DocsCorp.Pages
{
    class ProfilePage
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;
        WebDriverWait wait;
        public ProfilePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
        }

        private IWebElement ProfileButton
        {
            get
            {
                By profileLocation = By.LinkText("Profile");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(profileLocation));
            }
        }
        private IWebElement SetupProfile
        {
            get
            {
                By profileLocation = By.LinkText("Set up profile");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(profileLocation));
            }
        }
        private IWebElement EditProfile
        {
            get
            {
                By profileLocation = By.LinkText("Edit profile");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(profileLocation));
            }
        }
        private IWebElement UploadImage
        {
            get
            {
                By upladImage = By.XPath("//input[@data-testid='fileInput']");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(upladImage));
            }
        }
        private IWebElement UploadImageOnEditProfile
        {
            get
            {
                By uploadFiles = By.XPath("//input[@type='file']");
              


                //t.ElementAt(1).SendKeys(xxx);
                // By upladImage = By.XPath("//input[@type='file'])[1]");
                wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
                var waitForCollection = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(uploadFiles));
                var uploadFilesCollection = _webDriver.FindElements(uploadFiles).ToList();
                IWebElement uploadFile = uploadFilesCollection.ElementAt(1);
                return uploadFile;
            }
        }

        internal void ClickOnSave()
        {
            SaveButton.Click();
        }

        private IWebElement ApplyButton
        {
            get
            {
                By applyButton = By.XPath("//*[text()='Apply']");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(applyButton));
            }
        }
        private IWebElement SaveButton
        {
            get
            {
                By saveButton = By.XPath("//*[text()='Save']");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(saveButton));
            }
        }
        private IWebElement TweetButton
        {
            get
            {
                By tweetButton = By.LinkText("Tweet");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(tweetButton));
            }
        }
        private IWebElement TweetContainer
        {
            get
            {
                By tweetContainer = By.XPath("(//*[@data-offset-key])[1]");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(tweetContainer));
            }
        }
        private IWebElement TweetButtonOnPopup
        {
            get
            {
                By tweetButton = By.XPath("(//*[text()='Tweet'])[1]");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(tweetButton));
            }
        }
        public void ClickOnProfile()
        {
            ProfileButton.Click();
        }
        public void ClickOnSetupProfile()
        {
            SetupProfile.Click();
        }
        public void UploadImageProfile()
        {
            UploadImage.SendKeys("profile.jpg");
        }
        public void UploadImageProfileOnEditProfile()
        {
            var fullPath = Path.GetFullPath(@"resources/profile.jpg");
            UploadImageOnEditProfile.SendKeys(fullPath);
        }

        public void ClickOnApply()
        {
            ApplyButton.Click();
        }
        public void ClickOnTweetButton()
        {
            TweetButton.Click();
        }
        public void SendTweet(string tweetBody)
        {
            TweetContainer.SendKeys(tweetBody);
            TweetButtonOnPopup.Click();
        }
        public void ClickOnEditProfile()
        {
            EditProfile.Click();
        }
    }
}
