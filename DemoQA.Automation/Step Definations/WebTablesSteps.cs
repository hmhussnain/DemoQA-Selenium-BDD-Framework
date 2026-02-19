using DemoQA.Automation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DemoQA.Automation.StepDefinitions
{
    [Binding]
    public class WebTablesSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly WebTablesPage _webTablesPage;

        public WebTablesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("driver");
            _webTablesPage = new WebTablesPage(_driver);
        }

        [Given(@"User navigates to Web Tables page")]
        public void GivenUserNavigatesToWebTablesPage()
        {
            _webTablesPage.NavigateToWebTablesPage();
        }

        [When(@"User adds a new record")]
        public void WhenUserAddsANewRecord()
        {
            _webTablesPage.AddNewRecord();
        }

        [Then(@"Record should appear in table")]
        [Then(@"Record should appear in table")]
        public void ThenRecordShouldAppearInTable()
        {
            Assert.IsTrue(_webTablesPage.IsRecordPresent(),
                "Record was not added successfully.");
        }


        [When(@"User edits first record")]
        public void WhenUserEditsFirstRecord()
        {
            _webTablesPage.EditFirstRecord();
        }

        [Then(@"Record should be updated")]
        public void ThenRecordShouldBeUpdated()
        {
            Assert.IsTrue(_webTablesPage.IsRecordUpdated(), "Record was not updated successfully");
        }

        [When(@"User deletes first record")]
        public void WhenUserDeletesFirstRecord()
        {
            _webTablesPage.DeleteFirstRecord();
        }

        [Then(@"Record should be removed")]
        public void ThenRecordShouldBeRemoved()
        {
            Assert.IsTrue(_webTablesPage.IsRecordDeleted(), "Record was not deleted successfully");
        }
    }
}
