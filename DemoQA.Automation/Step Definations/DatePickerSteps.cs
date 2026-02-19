using DemoQA.Automation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace DemoQA.Automation.StepDefinitions
{
    [Binding]
    public class DatePickerSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly DatePickerPage _datePickerPage;

        public DatePickerSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            // Get driver from ScenarioContext (make sure Hooks.cs initializes it)
            _driver = _scenarioContext.Get<IWebDriver>("driver");

            // Initialize DatePickerPage with driver
            _datePickerPage = new DatePickerPage(_driver);
        }

        [Given(@"User navigates to Date Picker page")]
        public void GivenUserNavigatesToDatePickerPage()
        {
            _datePickerPage.NavigateToDatePickerPage();
        }

        [When(@"User selects day (.*)")]
        public void WhenUserSelectsDay(int day)
        {
            _datePickerPage.SelectDate(day);
        }

        [Then(@"Selected date should be displayed")]
        public void ThenSelectedDateShouldBeDisplayed()
        {
            string selectedDate = _datePickerPage.GetSelectedDate();
            Assert.IsFalse(string.IsNullOrEmpty(selectedDate), "Date was not selected successfully.");
        }
    }
}
