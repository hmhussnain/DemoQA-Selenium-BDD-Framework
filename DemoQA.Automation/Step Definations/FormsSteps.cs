using DemoQA.Automation.Pages;
using DemoQA.Automation.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DemoQA.Automation.StepDefinitions
{
    [Binding]
    public class FormsSteps
    {
        private readonly FormsPage _formsPage;

        public FormsSteps()
        {
            _formsPage = new FormsPage(DriverFactory.GetDriver());
        }

        [Then(@"Success modal should be displayed")]
        public void ThenSuccessModalShouldBeDisplayed()
        {
            Assert.IsTrue(_formsPage.IsSuccessModalDisplayed());
        }

        [When(@"User fills form with invalid email")]
        public void WhenUserFillsFormWithInvalidEmail()
        {
            _formsPage.FillForm("John", "Doe", "invalidemail");
        }

        [Then(@"Email validation error should be displayed")]
        public void ThenEmailValidationErrorShouldBeDisplayed()
        {
            Assert.IsTrue(_formsPage.IsEmailInvalid());
        }
    }
}
