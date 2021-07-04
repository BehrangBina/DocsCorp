using DocsCorp.Pages;
using DocsCorp.WebBrowser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DocsCorp.StepDefinition
{
    [Binding]
    class StepDef
    {
        private  static IWebDriver _driver;

        [BeforeFeature]
        public static void Setup()
        {
            _driver = new BrowserDriver().Current;
        }
        [Then(@"User inputs the Password (.*)")]
        public void ThenUserInputsThePassword(string password)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.InputPassword(password);
        }
        [Given(@"User Navigates to  (.*)")]
        public void GivenUserNavigatesTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        [Then(@"Clicks on the Login button on LandingPage")]
        public void ThenClicksOnTheLoginButtonOnLandingPage()
        {
            LandingPage landingPage = new LandingPage(_driver);
            landingPage.ClickOnLogin();
        }
        [Then(@"User inputs the UserName (.*)")]
        public void ThenUserInputsTheUserName(string userName)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.InputUserName(userName);
        }
        [Then(@"Clicks on the Login botton on LoginPage")]
        public void ThenClicksOnTheLoginBottonOnLoginPage()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
        }
        [Given(@"User is Loged in to  (.*) With (.*) and (.*)")]
        public void GivenUserIsLogedInToHttpsTwitter_ComWithBehrangAndAutomationtesting(string url,string userName,string password)
        {
            GivenUserNavigatesTo( url);
            ThenClicksOnTheLoginButtonOnLandingPage();
            ThenUserInputsTheUserName(userName);
            ThenUserInputsThePassword(password);
            ThenClicksOnTheLoginBottonOnLoginPage();
        }
        [Then(@"User Can send a text tweet of (.*)")]
        public void ThenUserCanSendATextTweetOfTestingAutomaticTweet(string tweetBody)
        {
            ProfilePage profilePage = new ProfilePage(_driver);
            profilePage.ClickOnTweetButton();
            profilePage.SendTweet(tweetBody);
            Assert.IsTrue(_driver.PageSource.Contains(tweetBody),$"Tweet should be in the body: {tweetBody}");
        }
        [Then(@"user Edits the profile picture")]
        public void ThenUserEditsTheProfilePicture()
        {
            ProfilePage profilePage = new ProfilePage(_driver);
            profilePage.ClickOnProfile();
            profilePage.ClickOnEditProfile();
            profilePage.UploadImageProfileOnEditProfile();
            profilePage.ClickOnApply();
            profilePage.ClickOnSave();

        }

        [AfterFeature]
        public static void TearDown()
        {
            _driver?.Dispose();
        }





    }
}
