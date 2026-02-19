using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using DemoQA.Automation.Pages;
using DemoQA.Automation.Utilities;

namespace DemoQA.Automation.StepDefinitions
{
    [Binding]
    public class FileUploadSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly FileUploadPage _fileUploadPage;

        public FileUploadSteps()
        {
            _driver = DriverFactory.GetDriver();
            _homePage = new HomePage(_driver);
            _fileUploadPage = new FileUploadPage(_driver);
        }

        [Given(@"User navigates to Upload page")]
        public void GivenUserNavigatesToUploadPage()
        {
            _homePage.NavigateToElementsSection();
            _homePage.NavigateToUploadDownload();
        }

        [When(@"User uploads a file")]
        public void WhenUserUploadsAFile()
        {
            _fileUploadPage.UploadFile();
        }

        [Then(@"File name should be displayed")]
        public void ThenFileNameShouldBeDisplayed()
        {
            Assert.IsTrue(_fileUploadPage.IsFileUploaded(),
                "File upload failed.");
        }
    }
}
